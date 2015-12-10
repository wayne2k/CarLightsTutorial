using UnityEngine;
using System.Collections;

public class CarLights : MonoBehaviour
{
    public Renderer breakLights;
    public Material brealKightOn;
    public Material breakLightOff;

    public Renderer headLights;
    public Material headightOn;
    public Material headLightOff;

    public Renderer turnSignalLeft;
    public Material turnSignalLeftOn;
    public Material turnSignalLeftOff;

    public Renderer turnSignalRight;
    public Material turnSignalRightOn;
    public Material turnSignalRightOff;

    public Light spotLightRight;
    public Light spotLightLeft;

    bool rightSignalOn;
    bool leftSignalOn;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.DownArrow))
        {
            breakLights.material = brealKightOn;
        }
        else
        {
            breakLights.material = breakLightOff;
        }

        if (Input.GetKeyDown ("1"))
        {
            headLights.material = headightOn;
            spotLightRight.intensity = 8f;
            spotLightLeft.intensity = 8f;
        }
        if (Input.GetKeyDown("2"))
        {
            headLights.material = headLightOff;
            spotLightRight.intensity = 0f;
            spotLightLeft.intensity = 0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            turnSignalRight.material = turnSignalRightOn;
            turnSignalLeft.material = turnSignalLeftOff;
            rightSignalOn = true;
            leftSignalOn = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnSignalRight.material = turnSignalRightOff;
            turnSignalLeft.material = turnSignalLeftOn;
            rightSignalOn = false;
            leftSignalOn = true;
        }
        else
        {
            turnSignalRight.material = turnSignalRightOff;
            turnSignalLeft.material = turnSignalLeftOff;
            leftSignalOn = false;
            rightSignalOn = false;
        }

        if (leftSignalOn)
        {
            float floor = 0f;
            float ceiling = 1f;
            float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);

            turnSignalLeft.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
        }
        if (rightSignalOn)
        {
            float floor = 0f;
            float ceiling = 1f;
            float emission = floor + Mathf.PingPong(Time.time * 2f, ceiling - floor);

            turnSignalRight.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f) * emission);
        }
    }
}

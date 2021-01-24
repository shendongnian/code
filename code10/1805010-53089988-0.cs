    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Ballmove : MonoBehaviour {
    public KeyCode moveL;
    public KeyCode moveR;
    public float horizVel = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(-4, GM.vertVol, horizVel);
        if (Input.GetKeyDown(moveL))
        {
            horizVel = -3;
            StartCoroutine(stopSlid());
        }
        if (Input.GetKeyDown(moveR))
        {
            horizVel = 3;
            StartCoroutine(stopSlid());
        }
    }
    IEnumerator stopSlid()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
    }
    }

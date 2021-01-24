    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class CreateButtons : MonoBehaviour {
    
    	public GameObject testObject;
    	public Vector2 generatePositionStart;
    	public Vector2 generatePositionEnd;
    	public float radius = 50f;
    
    	// Use this for initialization
    	void Start () {
    		Vector3 pointS = GetPoint (radius, generatePositionStart.y * Mathf.Deg2Rad, -generatePositionStart.x * Mathf.Deg2Rad);
    		GameObject start = Instantiate (testObject, pointS, Quaternion.identity) as GameObject;
    		start.name = "Start";
    		Vector3 pointE = GetPoint (radius, generatePositionEnd.y * Mathf.Deg2Rad, -generatePositionEnd.x * Mathf.Deg2Rad);
    		GameObject end = Instantiate (testObject, pointE, Quaternion.identity) as GameObject;
    		end.name = "End";
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}
    
    	Vector3 GetPoint (float rho, float theta, float phi) {
    		float x = rho * Mathf.Sin (theta) * Mathf.Cos (phi);
    		float y = rho * Mathf.Sin (phi);
    		float z = rho * Mathf.Cos (theta) * Mathf.Cos (phi);
    		return new Vector3 (x, y, z);
    	}
    }

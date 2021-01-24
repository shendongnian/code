    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class EngineController : MonoBehaviour 
    {
    	private bool facingRight;
    	private float moveHorizontal;
    
    	void Start()
    	{
    		facingRight = true;
    	}
    
    	void Update()
    	{
    		moveHorizontal = Input.GetAxis ("Horizontal");
    		Vector3 rot;
    		if (GetFacing () == -1f) {
    			rot = new Vector3 (-90, 0, 0);
    		}
    		else
    		{
    			rot = new Vector3 (90, 0, 0);
    		}
    
    		transform.rotation = Quaternion.Euler(rot);
    	}
    
    	public float GetFacing()
    	{
    		if (facingRight) {
    			return 1;
    		} 
    		else 
    		{
    			return -1;
    		}
    	}
    }

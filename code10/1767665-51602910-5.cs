    using UnityEngine;
    using System.Collections;
    
    public class OpenDoor : MonoBehaviour {
    
    	// define the possible states through an enumeration
    	public enum motionDirections {Left,Right};
    	// store the state
    	public motionDirections motionState = motionDirections.Left;
    	
    	//Variables for State Machine
    	bool mOpening = false;
    	bool mClosing = false;
    	
    	//bool mOpened = false;
    
    	//OpenRanges to open/close the door
    	public int OpenRange = 5;
    	public GameObject StopIn;	
    	public GameObject StartIn;
    	
    	//Variables for Movement
    	float SpeedDoor = 8f;
    	float MoveTime = 0f;	
    	
    	int CounterDetections = 0;
  
    	
    	void Update () {
    		// if beyond MoveTime, and triggered, perform movement
    		if (mOpening || mClosing) {/*Time.time >= MoveTime && */
    			Movement();
    		}
    	}
    	
    	void Movement()
    	{
    		if(mOpening)
    		{
    			transform.position = Vector3.MoveTowards(transform.position, StopIn.transform.position, SpeedDoor * Time.deltaTime);
    			
    			if(Vector3.Distance(transform.position, StopIn.transform.position) <= 0)
    				mOpening = false;
    
    		}else{ //This means it is closing
    		
    			transform.position = Vector3.MoveTowards(transform.position, StartIn.transform.position, SpeedDoor * Time.deltaTime);
    			
    			if(Vector3.Distance(transform.position, StartIn.transform.position) <= 0)
    				mClosing = false;
    				
    		}
    	}
    	
    	// To decide if door should be opened or be closed
    	void OnTriggerEnter(Collider Other)
    	{
    		print("Tag: "+Other.gameObject.tag);
    	
    		if(Other.gameObject.tag == "Enemy" || Other.gameObject.tag == "Player" || Other.gameObject.tag == "Elevator")
    		{
    			CounterDetections++;
    			if(!mOpening)
    				Opening();
    		}		
    	}
    	
    	void OnTriggerStay(Collider Other)
    	{
    		if(Other.gameObject.tag == "Elevator")
    		{
    			if(!mOpening)
    				Opening();
    		}
    	}
    	
    	void OnTriggerExit(Collider Other)
    	{
    		if(Other.gameObject.tag == "Enemy" || Other.gameObject.tag == "Player")
    		{
    			CounterDetections--;
    			if(CounterDetections<1)
    				Closing();
    		}
    	}
    	
    	void Opening()
    	{
    		mOpening = true;
    		mClosing = false;
    	}
    	
    	void Closing()
    	{
    		mClosing = true;
    		mOpening = false;
    	}
    }

    CameraFollow m_MainCamera;
    
    void Start()
    {
    	m_MainCamera = Camera.main.GetComponent<CameraFollow>();	
    }
    
    OnTriggerEnter(collider coll)
    {
    	if(coll.gameObject.tag == "rock")
    	{
    		m_MainCamera.SwapTargetTo(coll.transform);
    	}		
    }

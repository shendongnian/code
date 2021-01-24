    private HorizontalAxis hAxis;
    
    public void Start(){
    	GameObject taxi = GameObject.Find("Taxi");
    	if(taxi != null){ 
    		hAxis = taxi.GetComponent<CarAgent>().HorizontalAxis;
    	}
    }
    
    public void Update(){
       if(hAxis != null)
         transform.rotation = new Quaternion(0, 0, hAxis, 360);
    }
    
    public void FixedUpdate(){
    	if(hAxis != null){
    		// Do only Physics related stuff: rigidbodies, raycast
            // inputs and transform operations should stay in the Update()
    	}
    }

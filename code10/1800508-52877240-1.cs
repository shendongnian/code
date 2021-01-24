        VideoPlayer video;
    
    	public VideoClip vid1;
    	public VideoClip vid2;
    	// Use this for initialization
    	void Start () {
    		video = GetComponent<VideoPlayer>();
    	}
    	
    	// Update is called once per frame
    	void Update () {
    
    		if (Input.GetKey(KeyCode.Mouse0))
    		{
    			video.clip = vid1;
    			
    		}
    		else if (Input.GetKey(KeyCode.Mouse1))
    		{
    			video.clip = vid2;
    		}
    	} 

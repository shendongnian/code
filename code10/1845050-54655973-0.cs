    void Update()
    {
    	if (!rb.velocity.magnitude <= 0.01f && !Animation.IsPlaying(nameOfAnimation))
    	{
    		Debug.Log("We're not moving and the animation is not playing");
    	}
    }

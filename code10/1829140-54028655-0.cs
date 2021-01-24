    private bool WPressedFirst = false;
    private bool SPressedFirst = false;
    private bool APressedFirst = false;
    private bool DPressedFirst = false;
    
    void Update()
    {
        bool w, a, s, d;
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
    	
        // if any key isn't being pressed, set its pressedfirst value to false
    	if(!w)
    	{
    		WPressedFirst = false;
    	}
    	if(!a)
    	{
    		APressedFirst = false;
    	}
    	if(!s)
    	{
    		SPressedFirst = false;
    	}
    	if(!d)
    	{
    		DPressedFirst = false;
    	}
    	
        // if a key is being pressed AND the other one isn't, set it to pressedfirst true
    	if(w && !SPressedFirst)
    	{
    		WPressedFirst = true;
    	}
    	if(s && !WPressedFirst)
    	{
    		SPressedFirst = true;
    	}
    	if(a && !DPressedFirst)
    	{
    		APressedFirst = true;
    	}
    	if(d && !APressedFirst)
    	{
    		DPressedFirst = true;
    	}
    
        // only allow movement in a direction if it is pressed and the other isn't pressed
        // OR if it is pressed and the other was pressed first.
        if (w && (!s || SPressedFirst))
        {
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        }
        if (a && (!d || DPressedFirst))
        {
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (s && (!w || WPressedFirst))
        {
            transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        }
        if (d && (!a || APressedFirst))
        {
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
    
        }
    }

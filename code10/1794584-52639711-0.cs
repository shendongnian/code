    // in Form 2
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form1.IsForm2Closed = true;
    }
-------------------------
    // in Form 1
    private static _isForm2Closed ;
    public static bool IsForm2Closed 
    {
    	get
    	{
    		return _isForm2Closed;
    	}
    	set
    	{
    		_isForm2Closed = value;
    		// do whatever you want to execute here.
    	}
    }

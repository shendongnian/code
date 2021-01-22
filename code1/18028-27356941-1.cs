    public event EventHandler MyEvent;
	void SomeFunction()
	{
		// code ...
		
        //---------------------------
		MyEvent.Raise(this);
        //---------------------------
	}

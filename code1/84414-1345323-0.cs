    class MySampleClass{
    	public event ProcessCompleteEventHandler ProcessComplete;
    
    	void SomeWork()
    	{
    		//Do some work, and when its over...
    		ProcessComplete.Invoke(this, null);
    	}
    
    }

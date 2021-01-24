	void Main()
	{
		var subject = new Subject<bool>();
		subject.Subscribe(b => b.Dump(), e => { e.Throw(); }, () => {});
		subject.OnError(new Exception()); //This call is throwing!
	}
    public static class X
    {
    	public static void Throw(this Exception exception)
    	{
    		 System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception).Throw();
    	}
    }

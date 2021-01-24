	void Main()
	{
		var subject = new Subject<bool>();
		// subject.Subscribe();
		subject.Subscribe(b => {/* bool handling code */}, e => { });
		subject.OnError(new Exception()); //This call is throwing!
	
	}

	void Main()
	{
		var subject = new Subject<bool>();
		subject.Subscribe(b => {/* bool handling code */});
		subject.OnError(new Exception()); //This call is throwing!
	}

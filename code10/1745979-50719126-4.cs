	public void SendCommandSync()
	{
		SendCommandToServer();
		bool haveAnswer = false;
		Task.Delay(5000).ContinueWith(t =>
		{
			haveAnswer = IsAnwerHere();
	
			if (!haveAnswer) {/* after 5 secs still no answer from server*/}
		});	
	}

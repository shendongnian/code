	void OpenState(ReferenceTo<State> state)
	{
		timer = new System.Timers.Timer(CircuitBreaker.timeout);
		timer.Start();
		timer.Elapsed += new System.Timers.ElapsedEventHandler((sender, e) => state.Value = new State());       
	}	

	public void Run()
	{
		var state = new ReferenceTo<State>(new State());
		OpenState(state);
		for (int i=0; i<10; i++)
		{
			Console.WriteLine("{0:yyyy:MM:dd HH:mm:ss} State is {1}", DateTime.Now, state.Value);
			System.Threading.Thread.Sleep(100);
		}
	}

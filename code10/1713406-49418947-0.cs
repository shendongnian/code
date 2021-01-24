	void Main()
	{
		//static initializers
		List<int> expectedElements = new List<int> { 8, 10, 11 };
		List<int> elementHistory = new List<int>();
		IObservable<char> source;
	
		//simulated continuous running of MSpec test
		for (int i = 0; i < 20; i++)
		{
	
			//establish
			source = "Z8\nZ10\nZ11\n".ToObservable();
	
			//because
			source
				.ShutterCurrentReadings()
				.Trace("Unbelievable")
				.SubscribeAndWaitForCompletion(item => elementHistory.Add(item));
	
			//it
			elementHistory.Dump(i.ToString()); //Linqpad
			if(elementHistory.Count > 3)
				throw new Exception("Assert.ShouldNotHappen");
		}
	}

	public IEnumerable<string> GetData()
	{
		foreach(String name in _someInternalDataCollection)
		{
			yield return name;
		}
	}
	
	...
	
	public void DoSomething()
	{
		foreach(String value in GetData())
		{
			//... Do something with value that doesn't modify _someInternalDataCollection
		}
	}

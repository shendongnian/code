	void Main()
	{
        // custom implementation of IEnumerator<T>
		foreach (int i in new CustomEnumerable())
		{
			Console.WriteLine(i);
		}	
        // your original implementation—will produce same results
        // note: I assume someObject implements IEnumerable<T> and hence your GetEnumerator() method
		foreach (int i in someObject)
		{
			Console.WriteLine(i);
		}	
	}
	

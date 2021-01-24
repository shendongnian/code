	void Main()
	{
		Console.WriteLine(((object)Result.Pass) == (object)Result.Pass);
        // False
	}
	
	public enum Result{
		Pass, Fail
	}

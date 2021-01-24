	void Main()
	{
		Console.WriteLine(((object)Result.Pass) == (object)Result.Pass);
		// False
		Console.WriteLine(((object)Result.Pass).Equals((object)Result.Pass));
		// True
		
		Console.WriteLine(object.Equals((object)Result.Pass,(object)Result.Pass));
		// True
	}
	public enum Result{
		Pass, Fail
	}

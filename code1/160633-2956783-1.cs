	public static IEnumerable<int> GetNumbers() {
		try
		{
			Console.WriteLine("Start");
			yield return 1;
			yield return 2;
			yield return 3;
		}
		finally
		{
			Console.WriteLine("Finish");
		}
	}
...
    foreach(int i in GetNumbers()) {
        Console.WriteLine(i);
        if(i == 2) break;
    }

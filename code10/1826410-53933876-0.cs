    public static void Main()
	{
		var h = new HashSet<int> () {1, 2, 3, 4, 5};
		
		var d = h.OrderBy<int, int>(x => MyFunc(x));
		
		foreach(var a in d)
			Console.WriteLine(a); //will order based on the returned value of MyFunc(x). in descending order.
            // output will be 5 4 3 2 1 instead of 1 2 3 4 5.
	}
	
	public static int MyFunc(int x) 
	{
		return x * -1;
	}

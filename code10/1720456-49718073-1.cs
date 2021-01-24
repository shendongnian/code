    public static void Main()
	{
		C c = new C();
		var a = c;
		Console.WriteLine(a.GetType()); // It still is of `C` type
		a.Show(); // Prints out "C.Show" 
		c.Show(); // Prints out "C.Show"
		Console.ReadLine();
	}

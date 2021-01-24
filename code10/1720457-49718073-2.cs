    public static void Main()
	{
		C c = new C();
		object a = c;
		Console.WriteLine(a.GetType()); // It still is of `C` type instead of object as you've set
		((A)a).Show(); // Prints out "C.Show" 
		c.Show(); // Prints out "C.Show"
		Console.ReadLine();
	}

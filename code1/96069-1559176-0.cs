    public class A {}
	
    public class B : A {}
    public static void Main()
    {
        Console.WriteLine(typeof(A) == typeof(B));                 // false
        Console.WriteLine(typeof(A).IsAssignableFrom(typeof(B)));  // true
        Console.WriteLine(typeof(B).IsSubclassOf(typeof(A)));      // true
    }

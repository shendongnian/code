    using System;					
    public class Program
    {
    	public static void Main()
    	{
    		Guid a1 = new Guid();
    		Console.WriteLine(a1);
    		Guid b1 = a1;
    		Console.WriteLine(b1);
    		a1 = Guid.NewGuid();
    		Console.WriteLine(a1);
    		Console.WriteLine(b1);
    	}
    }
	/* OUTPUT
	00000000-0000-0000-0000-000000000000
	00000000-0000-0000-0000-000000000000
	164f599e-d42d-4d97-b390-387e8a80a328
	00000000-0000-0000-0000-000000000000
	*/

    class Program
    {
    	static void Main(string[] args)
    	{
    		cs cal = new cs();
    		double a, b;
    		Console.WriteLine("Enter First Num: ");
    		a = double.Parse(Console.ReadLine());
    		Console.WriteLine("Enter Second Num: ");
    		b = double.Parse(Console.ReadLine());
    		Console.WriteLine("Summation = {0}\nDifference = {1}\nMultiplication = {2}", cs.adds(a, b), cal.subs(a, b), cs.muls(a, b));
    		Console.ReadLine();
    	}
    }
    
    class cs : cd { public static double adds(double x, double y) { return x + y; } }
    class cd : cm { public double subs(double x, double y) { return x - y; } }
    class cm { public static double muls(double x, double y) { return x * y; } }

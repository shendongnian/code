    struct Result
    {
    	public int add;
    	public int multiply;
    }
    static void Main(string[] args)
    {
    	int a = 10;
    	int b = 20;
    	var result = Add_Multiply(a, b);
    	Console.WriteLine(result.add);
    	Console.WriteLine(result.multiply);
    }
     
    private static Sonuc Add_Multiply(int a, int b)
    {
    	var result = new Result
    	{
    		add = a * b,
    		multiply = a + b
    	};
    	return result;
    }

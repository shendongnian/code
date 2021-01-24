    static Func<int[], int> Add = ((i) => i.Sum());
    
    public static void Main()
    {
    	Console.WriteLine(Add.Invoke(new[] {1,2,3,4,5}));
    		
    	Console.WriteLine(Add.Invoke(new[] {8}));
    		
    	Console.WriteLine(Add.Invoke(new[] {-2, -4, 6}));
    }
    //15
    //8
    //0

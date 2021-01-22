    static int i = 3;
    
    public static void ChangeIntRef(ref int val)
    {
       val = 5;
    }
    public static void ChangeInt(int val)
    {
       val = 5;
    }
	
    Console.WriteLine(i);
    ChangeInt(i);
    Console.WriteLine(i);
		
    ChangeIntRef(ref i);
    Console.WriteLine(i);

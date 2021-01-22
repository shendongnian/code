    #define DEBUG1
    
    ...
    
    public static void PrintText1(string txt)	{
        Console.Write("This is PrintText2\n");
    }
    [Conditional("DEBUG1")]
    public static void PrintText2(string txt)	{
        Console.Write("This is PrintText2\n");
    }
    [STAThread]
    static void Main(string[] args)    {
        PrintText1("This is the unconditional method");
        PrintText2("This function will be called only if 'DEBUG1' is defined");
    }

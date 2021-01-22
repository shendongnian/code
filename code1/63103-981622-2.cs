    [Conditional("DEBUG1")]
    public static void ConditionedPrint(string txt)	{
        Console.Write("This is PrintText2\n");
    }
    public static void UnconditionedPrint(string txt)     {
        ConditionedFunc(txt);
    }

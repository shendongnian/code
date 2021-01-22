    int i = 0;
    try
    {
        int j = 10 / i;
    }
    catch(DivideByZeroException e){}
    finally
    {
        Console.WriteLine("In finally");
        Console.ReadLine();
    }

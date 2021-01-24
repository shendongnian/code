    void Test(int i)
    {
        Console.WriteLine("int");
    }
    
    void Test(String s)
    {
        Console.WriteLine("String");
    }
    
    void RunMe()
    {
        dynamic obj = 1;
        // The right overload is picked at execution time
        Test(obj);
    }

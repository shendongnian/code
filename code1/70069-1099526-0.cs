    void Main()
    {
    DoSomething(2);
    DoSomething(EnumValue);
    	
    }
    
    public void DoSomething(int test) {
    DoSomething<int>(test);
    }
    
    // Define other methods and classes here
    public void DoSomething<T>(T test) {
    Console.WriteLine(test);
    }

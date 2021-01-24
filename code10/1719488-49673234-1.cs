    public bool functionA()
    {
        if(!specificCondition)
            return true;
        return false;
    }
    public void functionB()
    {
        if(!functionA())
            functionC();  
    }
    public void functionC()
    {
        Console.WriteLine("OK");
    }

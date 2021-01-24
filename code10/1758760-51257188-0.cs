    public void A()
    {
        string power = "test";
        
        {
             // this works because power is defined in a less deep scope.
             Console.WriteLine(power);
        }
    }
    public void B()
    {
        {
            string power = "test";
        }
        // this doesn't work because power is defined in a deeper scope
        Console.WriteLine(power); 
    }

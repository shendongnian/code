    using System;
    public void Method1()
    {
        CallingMethod(CalledMethod);
    }
    public void CallingMethod(Action method)
    {
        method();   // This will call the method that has been passed as parameter
    }
    public void CalledMethod()
    {
        Console.WriteLine("This method is called by passing parameter");
    }
    
    
    

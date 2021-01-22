    static void MyMethod()
    {
        Console.WriteLine("I was called by the Delegate special class!");
    }
    
    static void CallAnyMethod(Delegate yourMethod)
    {
        yourMethod.DynamicInvoke(new object[] { /*Array of arguments to pass*/ });
    }
    static void Main()
    {
        CallAnyMethod(MyMethod);
    }

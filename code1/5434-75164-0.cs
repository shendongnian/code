    public int SomeMethod(int someInput)
    {
    Thread.Sleep(20);
    Console.WriteLine(”Processed input : {0}”,someInput);
    return someInput+1;
    } 
    // Define a delegate
    delegate int SomeMethodDelegate(int someInput);
    SomeMethodDelegate someMethodDelegate = SomeMethod;
    
    // Call the method that does the real work
    // Give the method name that must be called once the work is completed.
    someMethodDelegate.BeginInvoke(10, // Input parameter to SomeMethod()
    EndSomeOtherMethod, // Callback Method
    someMethodDelegate); // AsyncState
    
    
    // Method that will be called after work is complete
    public void EndSomeOtherMethod(IAsyncResult result)
    {
    SomeMethodDelegate myDelegate = result.AsyncState as SomeMethodDelegate;
    // obtain the result
    int resultVal = myDelegate.EndInvoke(result);
    Console.WriteLine(”Returned output : {0}”,resultVal);
    }

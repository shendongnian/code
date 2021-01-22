    private static ManualResetEvent waitHandle = new ManualResetEvent(false);
    static void Main(string[] args)
    {
        var someObjectInstance = new SomeObject();
        someObjectInstance.SomeEvent += SomeEventHandler;
        waitHandle.WaitOne(); // Will block until event occurs
    }
    static void SomeEventHandler()
    {
        //some logic
        waitHandle.Set(); // Will allow Main() to continue, exiting the program
    }

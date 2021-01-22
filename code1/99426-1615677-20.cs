    [Test]
    public void Test_CallService ()
    {
        IMyWebService mockService = null;
        // instantiate mock with expectations
        MyClient client = new MyClient (mockService);
        client.CallService ();
        // verify results
    }

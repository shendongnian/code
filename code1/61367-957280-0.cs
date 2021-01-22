    [ServiceContract]
    public interface ITestCallback : IPing
    {
    	[OperationContract]
    	void TestCB ();
    }

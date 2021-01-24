    public delegate double FunctionCallback(int arg);
    [ComVisible(true)]
    [Guid("5F11C485-0AA8-461D-BB56-32D620D17311")]
    public interface ITestServer
    {
      double Connect([MarshalAs(UnmanagedType.FunctionPtr)] FunctionCallback callback, int arg);
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class TestServer : ITestServer
    { 
      public double Connect(FunctionCallback callback, int arg)
      {
        Console.Out.WriteLine("In server, calling callback...");
        return callback(arg);
      }  
    }

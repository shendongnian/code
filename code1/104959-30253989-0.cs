    public delegate void HelloFunctionDelegate(string message);
    class Program
    {
     static void Main()
    {
    HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);
    del("Hello from Delegate");
    }
    public static void Hello(string strMessage)
    {
     Console.WriteLine(strMessage);
    }
    }
    

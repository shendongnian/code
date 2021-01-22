    public delegate void ProcessMessageCallback(
            [MarshalAs(UnmanagedType.LPStr)] ref string ResponseMsg);
    
    static class test
    {
        [DllImport("test.dll")]
        static extern void TestCallback(ProcessMessageCallback callback);
    
        static public void Main(string[] args)
        {
            TestCallback(MyCallback);
        }
    
        static void MyCallback(ref string ResponseMsg)
        {
            ResponseMsg = "hi there";
        }
    }

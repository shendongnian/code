    public delegate void ProcessMessageCallback(StringBuilder ResponseMsg);
    static class test
    {
        [DllImport("test.dll")]
        static extern void TestCallback(ProcessMessageCallback callback);
        static public void Main(string[] args)
        {
            TestCallback(MyCallback);
        }
        static void MyCallback(StringBuilder ResponseMsg)
        {
            ResponseMsg.Append("hi there");
        }
    }

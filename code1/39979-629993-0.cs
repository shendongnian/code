    private delegate int LongRunningTaskHandler();
    static void Main(string[] args) {
        LongRunningTaskHandler handler = LongRunningTask;
        handler.BeginInvoke(MyCallBack, null);
        Console.ReadLine();
    }
    private static void MyCallBack(IAsyncResult ar) {
        var result = (LongRunningTaskHandler)((AsyncResult) ar).AsyncDelegate;
        Console.WriteLine(result.EndInvoke(ar));
    }
    public static int LongRunningTask()
    {
        Thread.Sleep(5000);
        return 42;
    }

    public static void ExecuteMethod1InThread(string msg)
    {
        Thread t = new Thread(delegate() { log(msg); });
        t.IsBackground = true;
        t.Start();
        t.Join();
    }

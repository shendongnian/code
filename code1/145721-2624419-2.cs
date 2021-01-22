    var dict = new Dictionary<int, string>() { { 1234, "OK" } };
    new Thread(() =>
    {
        for (; ; )
        {
            string s;
            if (!dict.TryGetValue(1234, out s))
            {
                throw new Exception();  // #1
            }
            else if (s != "OK")
            {
                throw new Exception();  // #2
            }
        }
    }).Start();
    Thread.Sleep(1000);
    Random r = new Random();
    for (; ; )
    {
        int k;
        do { k = r.Next(); } while (k == 1234);
        Debug.Assert(k != 1234);
        dict[k] = "FAIL";
    }

    for (int i = 0; i < 50; i++)
    {
        // Non-threaded
        //AddNumbers();
        //Console.WriteLine((i + 1).ToString());
        // Threaded
        int iCopy = i;
        new Thread(() =>
        {
            //Thread.CurrentThread.IsBackground = true;
            AddNumbers();
            Thread.Sleep(1000);
            Console.WriteLine((iCopy + 1).ToString());
        }).Start();
    }

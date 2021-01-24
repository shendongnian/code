    void DoStuff()
    {
        while (true)
        {
            Task.Factory.StartNew(() => DoWork1())
                .ContinueWith((t1) => DoWork2())
                .ContinueWith(t2 => DoWork3())
                .Wait();
        }
    }

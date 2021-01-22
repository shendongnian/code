    // Fields
    Stopwatch watch = new Stopwatch();
    static TimeSpan? GetInternetIdleTime()
    {
        if (IsInternetIdle())
        {
            if (!watch.IsRunning)
            {
                watch.Start();
            }
            //Console.WriteLine("Idle Time: {0}", XmlConvert.ToString(watch.Elapsed));
            return watch.Elapsed;
        }
        else
        {
            watch.Stop();
            watch.Reset();
            return null;
        }
    }

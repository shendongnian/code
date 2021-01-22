    static void test()
    {
        _eventsRaised += 1;
        //if it was more than a second since the last event (ie, it's a new save), then wait for 3 seconds (to avoid 
        //multiple events for the same file save) before processing
        if (DateTime.Now.Ticks - _lastEventTicks > 1000)
        {
            Thread.Sleep(3000);
            _lastEventTicks = DateTime.Now.Ticks;
            _eventsRespondedTo += 1;
            Console.WriteLine("File changed. Handled event {0} of {1}.", _eventsRespondedTo, _eventsRaised);
            //stop threads and then restart them
            thread1.Stop();
            thread2.Stop();
            thread1 = new WorkerThread("foo", 20);
            thread2 = new WorkerThread("bar", 30);
        }
    }

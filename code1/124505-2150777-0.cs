    OneShotHandlerQueue<EventArgs> queue = new OneShotHandlerQueue<EventArgs>();
    Test test = new Test();
    // attach permanent event handler
    test.Done += queue.Handle;
    // add a "one shot" event handler
    queue.Add((sender, e) => Console.WriteLine(e));
    test.Start();
    // add another "one shot" event handler
    queue.Add((sender, e) => Console.WriteLine(e));
    test.Start();

    while (true)
    {
         allDone.Reset();
         server.BeginAccept(new AsyncCallback(AcceptCon), server);
         allDone.WaitOne(); // <------
    }

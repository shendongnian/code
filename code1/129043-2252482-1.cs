    while (IsRunning)
    {
        do
        {
            MyObj myObj = queue.Dequeue();
            if (myObj != null)
            {
                DoSomethingWith(myObj);
            }
        } while (myObj != null);
        myAutoResetEvent.WaitOne();
    }

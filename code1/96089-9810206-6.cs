    lock(phone)
    {
        while(true)
        {
            if(Monitor.Wait(phone,1000)) // Wait for one second at most
            {
                DoWork();
                Monitor.PulseAll(phone); // Signal boss we are done
            }
            else
                DoSomethingElse();
        }
    }

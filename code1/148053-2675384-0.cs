    Arbiter.Activate(dispatcherQueue, Arbiter.Interleave(
        new TeardownReceiverGroup(Arbiter.Receive<bool>(
            false, mainPort, new Handler<bool>(Teardown))),
        new ExclusiveReceiverGroup(Arbiter.Receive<object>(
            true, mainPort, new Handler<object>(WriteData))),
        new ConcurrentReceiverGroup(Arbiter.Receive<string>(
            true, mainPort, new Handler<string>(ReadAndProcessData)))));
    public void WriteData(object data)
    {
        // write data to the dictionary
        // this code is never executed in parallel so no synchronization code needed
    }
    public void ReadAndProcessData(string s)
    {
        // this code gets scheduled to be executed in parallel
        // CCR take care of the task scheduling for you
    }
    public void Teardown(bool b)
    {
        // clean up when all tasks are done
    }

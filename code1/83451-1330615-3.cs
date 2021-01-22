    private static volatile bool done;
    void Thread1()
    {
        while (!done)
        {
            // do work
        }
    }
    void Thread2()
    {
        // do work
        done = true;
    }

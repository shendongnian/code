    System.Threading.Semaphore sem = new System.Threading.Semaphore(0, 1, "FileWriter");
    while (sem.WaitOne())
    {
        // Do work
        sem.Release();
    }

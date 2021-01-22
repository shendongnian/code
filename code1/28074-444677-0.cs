    System.Threading.Semaphore S = new System.Threading.Semaphore(0, 3);
    try
    {
        // wait your turn (increment)
        S.WaitOne();
        // do your thing
    }
    finally {
        // release so others can go (decrement)
        S.Release();
    }

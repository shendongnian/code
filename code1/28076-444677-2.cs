    System.Threading.Semaphore S = new System.Threading.Semaphore(3, 3);
    try
    {
        // wait your turn (decrement)
        S.WaitOne();
        // do your thing
    }
    finally {
        // release so others can go (increment)
        S.Release();
    }

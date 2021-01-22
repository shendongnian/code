    bool entered = false;
    try { 
      System.Threading.Monitor.Enter(x, ref entered);
      ... 
    }
    finally { if (entered) System.Threading.Monitor.Exit(x); }

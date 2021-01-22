    object obj = x;
    System.Threading.Monitor.Enter(obj);
    try {
       …
    }
    finally {
       System.Threading.Monitor.Exit(obj);
    }

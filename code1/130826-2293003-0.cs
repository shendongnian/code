    System.Threading.Monitor.Enter(x);
    try {
       ...
    }
    finally {
       System.Threading.Monitor.Exit(x);
    }

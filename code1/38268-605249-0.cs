    class lanmessenger
    {
        ...
        TcpListener t = new TcpListener(5555);  // ok to initialize like this
        t.Start();  // wrong...put this in a method
    }

    // C# 3+ lambda syntax
    Collection.CreateNewMessage("FileDownlading", () => {
        // I wonder how long it is taking me to download this file in production?    
        // Lets log it in a message and store for later pondering.    
        WebClass.DownloadAFile("You Know This File Is Great.XML");
    });
    // C# 2 anonymous delegate syntax
    Collection.CreateNewMessage("FileDownlading", delegate() {
        // I wonder how long it is taking me to download this file in production?    
        // Lets log it in a message and store for later pondering.    
        WebClass.DownloadAFile("You Know This File Is Great.XML");
    });
    // Method
    void CreateNewMessage(string name, Action action) {
       StopWatch sw = StopWatch.StartNew();
       try {
          action();
       } finally {
          Log("{0} took {1}ms", name, sw.ElapsedMilliseconds);
       }
    }

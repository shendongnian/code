    public void Method1 () {
        for (int i = 0; i < 10; i++) {
            System.Console.WriteLine ("Method1: {0}", i);
            Thread.Sleep (2000); // 2 seconds
        }
    }
    public void Method2 () {
        for (int i = 0; i < 10; i++) {
            System.Console.WriteLine ("Method2: {0}", i);
            Thread.Sleep (2000); // 2 seconds
        }
    }

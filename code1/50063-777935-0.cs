    private static readonly object lockObject = new object();
    public static void Method() {
        lock(lockObject) { 
             // ...
        }
    }

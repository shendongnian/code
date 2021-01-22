    // See: no namespace here
    public static class System
    {
        public static void Main()
        {
            // "System" doesn't have a namespace, so this
            // will refer to this class!
            global::System.Console.WriteLine("Hello, world!");
        }
    }

    class Example
    {
        private ResultSet result;
    
        public Method1()
        {
            ResultSet result = null;
            RunSession(session => { result = ... });
        }
    
        public Method2()
        {
            // Something wrong here Bob. All our robots keep self-destructing!
            if (result == null)
                SelfDestruct(); // Always called
            else
            {
                // ...
            }
        }
        public static void Main(string[] args)
        {
            Method1();
            Method2();
        }
    }

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
            if (result == null)
                SelfDestruct(); // Always called
            else
            {
                // ...
            }
        }
    }

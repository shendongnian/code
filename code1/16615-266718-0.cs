    static class Program
    {
        static void Main() { }
    
        static readonly object sync = new object();
    
        static int GetValue() { return 5; }
    
        static int ReturnInside()
        {
            lock (sync)
            {
                return GetValue();
            }
        }
    
        static int ReturnOutside()
        {
            int val;
            lock (sync)
            {
                val = GetValue();
            }
            return val;
        }
    }

    class Program
    {
        static void Main (string[] args)
        {
            // Only one static variable is possible per Namespace.Class.Method scope
            MyStaticInt localStaticInt = new MyStaticInt (0);
            // Working with it
            localStaticInt.StaticValue = 5;
            int test = localStaticInt.StaticValue;
        }
    }

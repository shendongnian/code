    using System;
    class AlwaysEqual
    {
        public static bool operator ==(AlwaysEqual a, AlwaysEqual b)
        {
            return true;
        }
    
        public static bool operator !=(AlwaysEqual a, AlwaysEqual b)
        {
            return true;
        }
    }
    
    
    class Program
    {
        static void Main()
        {
            object o = new AlwaysEqual();
            AlwaysEqual ae = o as AlwaysEqual;
    
            if (ae == null)
            {
                Console.WriteLine("ae is null");
            }
    
            if ((object)ae == null)
            {
                Console.WriteLine("(object)ae is null");
            }
        }
    }

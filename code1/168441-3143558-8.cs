    using System;
    
    class Test
    {
        static void Main()
        {
            Test x = null;
            Console.WriteLine(x.Equals(null));
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override bool Equals(object other)
        {
            return other == this;
        }
    }

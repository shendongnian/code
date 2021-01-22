    using System;
    
    public class NaughtyType
    {
        public override int GetHashCode()
        {
            return 0;
        }
        
        public override bool Equals(object other)
        {
            return true;
        }
        
        public static bool operator ==(NaughtyType first, NaughtyType second)
        {
            return first.Equals(second);
        }
    
        public static bool operator !=(NaughtyType first, NaughtyType second)
        {
            return !first.Equals(second);
        }
    }
    
    public class Test
    {    
        static void Main()
        {
            NaughtyType nt = null;
            if (nt == null)
            {
                Console.WriteLine("Hmm...");
            }
        }
    }

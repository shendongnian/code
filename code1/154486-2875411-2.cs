    using System;
    public class Program
    {
        public static bool IsGuid(object item)
        {
            return item is Guid;
        }
        public static void Main()
        {
            Guid s = Guid.NewGuid();
            Console.Write(IsGuid(s));
        }
    }

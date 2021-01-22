    using System;
    
    public class Test
    {
        static void Main()
        {
            object x = new string(new char[0]);
            object y = new string(new char[0]);
            object z = "";
            Console.WriteLine(x == y); // True
            Console.WriteLine(x == z); // True
        }
    }

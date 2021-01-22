    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    
    
    public class MainClass
    {
        public static void Main()
        {
            int number = 10;
            string msg = "age is " + number + ".";
            msg += " great?";
            Console.WriteLine("msg: {0}", msg);
    
            String s1 = 10 + 5 + ": Two plus three is " + 2 + 3;
            String s2 = 10 + 5 + ": Two plus three is " + (2 + 3);
            Console.WriteLine("s1: {0}", s1);
            Console.WriteLine("s2: {0}", s2);    }
    
    }

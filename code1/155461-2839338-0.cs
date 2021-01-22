    using System;
    public class Program
    {
        public static class MyStaticClass
        {
            public static string myStaticMember = "";
        }
    
        static void Main()
        {
            MyStaticClass.myStaticMember = "Hello";
            Console.WriteLine(MyStaticClass.myStaticMember);
        }
    }

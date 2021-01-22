    using System;
    using MyFSharp;  // reference the F# dll
    class Program
    {
        static void Main(string[] args)
        {
            var s = "foo";
            //s.Awesome(); // no
            Console.WriteLine(s.Great());  // yes
        }
    }

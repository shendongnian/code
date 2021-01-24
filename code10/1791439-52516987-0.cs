    using System;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                char[] a = {(char)97, (char)776};
                string s = new string(a);
                Console.WriteLine(s + " -> " + s.Length); // Prints a¨ -> 2
                var t = s.Normalize();
                Console.WriteLine(t + " -> " + t.Length); // Prints ä -> 1
            }
        }
    }

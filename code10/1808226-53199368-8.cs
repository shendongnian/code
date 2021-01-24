    using System;
    namespace YourNameSpace
    {
       class Program
       {
        static void Main(string[] args)
        {
            string myString = "Hello World";
            char character = 'l';
            string result = myString.LeftOf(character);
            Console.WriteLine(result);
        }       
    }
    namespace YourNameSpace
    {
    public static class Extensions
    {
        public static string LeftOf(this string s, char c)
        {
            int ndx = s.IndexOf(c);
            if (ndx >= 0)
            {
                return s.Substring(0, ndx);
            }
            return s;
        }
    }

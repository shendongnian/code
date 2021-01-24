    using System;
    namespace YourNameSpace
    {
       class Program
       {
        static void Main(string[] args)
        {
            //The LeftOf Method requires two parameters 
            //First is the string you want to examine thats LeftOf first parameter s
            string myString = "Hello World";
            //Second parameter is the char c
            char character = 'l';
            //Invoke LeftOf it will return a string format
            string result = myString.LeftOf(character);
            //Check the result
            Console.WriteLine(result);
            //You can also do
            //Console.WriteLine(LeftOf(mystring, character);
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

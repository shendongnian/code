    using System;
    namespace YourNameSpace
    {
       class Program
       {
        static void Main(string[] args)
        {
            //The LeftOf Method requires one parameter as were using an extension
            //First is the string you want to examine the string now contains the extension LeftOf and the first parameter will use the string at hand.
            string myString = "Hello World";
            //The only parameter needed now is the character 
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

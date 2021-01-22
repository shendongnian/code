    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string s = "This Is {{ dsfdf {{dsfsd}} ewrwrewr }} My Result";
    
            Regex regex = new Regex("{{({?}?[^{}])*}}");
            int length;
            do
            {
                length = s.Length;
                s = regex.Replace(s, "");
            } while (s.Length != length);
    
            Console.WriteLine(s);
         }
    }

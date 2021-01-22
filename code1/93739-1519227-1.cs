    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            string x = @"
    A
    --ignore
    B
    --endignore
    C";
            Regex regex = new Regex("\r\n--ignore.*?\r\n--endignore\r\n", 
                                    RegexOptions.Singleline);
            string y = regex.Replace(x, "\r\n");
            Console.WriteLine(y);
        }
    }

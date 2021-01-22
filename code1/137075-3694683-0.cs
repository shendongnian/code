    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Program
    {
        bool isDivisibleBy3(string s)
        {
            int sumOfDigits = 0;
            foreach (char c in s)
            {
                sumOfDigits += c - '0';
            }
            return sumOfDigits % 3 == 0;
        }
    
        bool isDivisibleBy20(string s)
        {
            return Regex.IsMatch(s, "^0$|[02468]0$");
        }
    
        bool isDivisibleBy60(string s)
        {
            return isDivisibleBy3(s) && isDivisibleBy20(s);
        }
    
        bool isValid(string s)
        {
            return Regex.IsMatch(s, "^0$|^[1-9][0-9]*$");
        }
    
        Regex createRegex()
        {
            string a  = "[0369]*";
            string b = "a[147]";
            string c = "a[258]";
            string r = "^0$|^(?=.*[02468]0$)(?:(?:[369]|[147](?:bc)*(?:c|bb)|[258](?:cb)*(?:b|cc))0*)*0$";
            r = r.Replace("b", b).Replace("c", c).Replace("a", a);
            return new Regex(r);
        }
    
        void Run()
        {
            Regex regex = createRegex();
            Console.WriteLine(regex);
    
            // Test on 10000 random strings.
            Random random = new Random();
            for (int i = 0; i < 100000; ++i)
            {
                int length = random.Next(50);
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < length; ++j)
                {
                    sb.Append(random.Next(10));
                }
                string s = sb.ToString();
                bool isMatch = regex.IsMatch(s);
                bool expected = isValid(s) && isDivisibleBy60(s);
                if (isMatch != expected)
                {
                    Console.WriteLine("Failed for " + s);
                }
            }
        }
    
        static void Main()
        {
            new Program().Run();
        }
    }

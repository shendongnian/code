        static string ReverseNL (string s)
        {
            if ((s == null) || (s.Length <= 1))
            {
                return s;
            }
            return ReverseNL(s.Substring(1)) + s[0];
        }
        static void Main(string[] args)
        {
            string src = "The quick brown fox";
            Console.WriteLine(src);
            src = ReverseNL(src);
            Console.WriteLine(src);
        }

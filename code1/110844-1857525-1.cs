        static void Main(string[] args)
        {
            string s = "223232-1.jpg";
            Console.WriteLine(sep(s));
            s = "443-2.jpg";
            Console.WriteLine(sep(s));
            s = "34443553-5.jpg";
            Console.WriteLine(sep(s));
        Console.ReadKey();
        }
        public static string sep(string s)
        {
            int l = s.IndexOf("-");
            if (l >0)
            {
                return s.Substring(0, l);
            }
            return "";
        }

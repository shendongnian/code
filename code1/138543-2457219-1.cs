       static void Main(string[] args)
        {
            string s = "(x * n)(x + m)";
            Console.WriteLine(IsGood(s));
            string ss = " ( x + 12.9) (x+33.9)"; // even whitespace is taken care of!
            Console.WriteLine(IsGood(ss));
        }
        
        public static bool IsGood(string s)
        {
            double m=0;
            int c = 0;
            foreach (var item in s.Split(new char[] { '+', '-', '(', ')' }))
            {
                var xx = item.Trim();
                if (xx != "")
                {
                    switch (c)
                    {
                        case 0:
                        case 2:
                            if (xx == "x") c++;
                            break; 
                        case 1:
                        case 3:
                            if (double.TryParse(xx, out m)) c++;
                            break;
                    }
                }
            }
            return c == 4;
        }

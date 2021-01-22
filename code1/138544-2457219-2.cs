     class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(IsGood1("+x(3)-)x-5+"));
                Console.WriteLine(IsGood1("(x * n)(x + m)"));
                Console.WriteLine(IsGood1(" ( x + 12.9) (x+33.9)"));
            }
    
            private static bool IsOrdered(string s) // bad idea
            {
                var ind = new List<int>();
                ind.Add(s.IndexOf('('));
                ind.Add(s.IndexOfAny(new char[] { '+', '-' }));
                ind.Add(s.IndexOf(')'));
                ind.Add(s.LastIndexOf('('));
                ind.Add(s.LastIndexOfAny(new char[] { '+', '-' }));
                ind.Add(s.LastIndexOf(')'));
    
                bool order = true;
    
                for (int i = 0; i < ind.Count - 1; i++)
                {
                    order = order && (ind[i] < ind[i + 1]);
                }
                return order;
            }
    
            public static bool IsGood1(string s)
            {
                if (!IsOrdered(s)) return false;
    
                double m = 0;
                int c = 0;
                
                foreach (var item in s.Split(new char[] { '+', '-', '(', ')' }))
                {
                    var xx = item.Trim();
    
                    if (xx != "")
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
    
                return c == 4;
            }
    
        }

    static void foo(string s, List<Array> x, int a)
        {
            if (a == x.Count)
            {
                // output here
                Console.WriteLine(s);
            }
            else
            {
                foreach (object y in x[a])
                {
                    foo(s + y.ToString(), x, a + 1);
                }
            }
        }
    static void Main(string[] args)
        {
            List<Array> a = new List<Array>();
            a.Add(new string[0]);
            a.Add(new string[0]);
            a.Add(new string[0]);
            a[0] = new string[] { "T", "Z" };
            a[1] = new string[] { "N", "Z" };
            a[2] = new string[] { "3", "2", "Z" };
            foo("", a, 0);
            Console.Read();
        }

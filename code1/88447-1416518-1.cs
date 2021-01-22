    class x
    {
        public static void foo(params string[] ss)
        {
            foreach (string s in ss)
            {
                System.Console.WriteLine(s);
            }
        }
    
        public static void Main()
        {
            foo("a", "b", "c");
            string[] s = new string[] { "d", "e", "f" };
            foo(s);
        }
    }

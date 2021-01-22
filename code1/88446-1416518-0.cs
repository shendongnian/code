    class x
    {
        public static void foo(int c, params string[] ss)
        {
            foreach (string s in ss)
            {
                System.Console.WriteLine(s);
            }
        }
    
        public static void Main()
        {
            foo(5, "a", "b", "c");
        }
    }

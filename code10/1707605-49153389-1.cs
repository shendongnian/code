    public static class Program
    {
        private static void Main()
        {
            S1 s = default(S1);
            s.A = 1;
            S1 s2 = s;
            Program.S1Foo(ref s2);
            Console.WriteLine(s2.A);
        }
        private static void S1Foo([IsReadOnly] [In] ref S1 s)
        {
            S1 s2 = s;
            s2.ChangeA(2);
        }
    }

        public delegate void Action();
        static void Main()
        {
            DoStuff(delegate {Foo(5);});
            DoStuff(delegate {Bar("abc","def");});
        }
        static void DoStuff(Action action)
        {
            action();
        }
        static void Foo(int i)
        {
            Console.WriteLine(i);
        }
        static void Bar(string s, string t)
        {
            Console.WriteLine(s+t);
        }

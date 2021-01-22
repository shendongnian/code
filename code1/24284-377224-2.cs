        static void Main()
        {
            DoStuff(delegate (string s) {Foo(5);});
            DoStuff(delegate (string s) {Bar(s,"def");});
        }
        static void DoStuff(Action<string> action)
        {
            action("abc");
        }
        static void Foo(int i)
        {
            Console.WriteLine(i);
        }
        static void Bar(string s, string t)
        {
            Console.WriteLine(s+t);
        }

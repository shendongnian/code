    class Foo {
        public Action<string> DoSomethingDelegate1;
        public Action<string,string> DoSomethingDelegate2;
        public void DoSomething(string s) { DoSomethingDelegate1(s); }
        public void DoSomething(string s, string t) { DoSomethingDelegate2(s, t); }
    }
    class Bar
    {
        public Bar()
        {
            Foo f1 = new Foo();
            f1.DoSomethingDelegate1 = (s) => { Console.Write(s) };
            Foo f2 = new Foo();
            f2.DoSomethingDelegate2 = (s1, s2) => { Console.Write(s1 + s2) };
            
            f1.DoSomething("Hi");
            f2.DoSomething("Hi","World");
        }
    }

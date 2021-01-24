    Action a;
    ref struct S {
        public ReadOnlySpan<char> s;
        public void g() {
            foreach (var c in s)
                Console.Write(c);
        }
    }
    void f() {
        S s;
        s.s = "Hello, world!\n".AsReadOnlySpan();
        s.g(); // okay
        a = s.g; // error
    }

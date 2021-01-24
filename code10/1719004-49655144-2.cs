    Action a;
    void f() {
        var s = "Hello, world!\n".AsReadOnlySpan();
        void g() {
            foreach (var c in s)
                Console.Write(c);
        }
        a = g;
    }
    void h() {
        a(); //call a which is in fact the "local" method g in f
    }

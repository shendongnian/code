    static void Main() {
        long x = 17;
        Foo(x);
        var y = 17;
        Foo(y); // boom
    }
    static void Foo(long value)
    { Console.WriteLine(value); }
    static void Foo(int value) {
    throw new NotImplementedException(); }

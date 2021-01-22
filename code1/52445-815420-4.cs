    class Foo {
        int i; // on the heap
    }
    static void Foo() {
        int i = 0; // on the heap due to capture
        // ...
        Action act = delegate {Console.WriteLine(i);};
    }
    static IEnumerable<int> Foo() {
        int i = 0; // on the heap to do iterator block
        //
        yield return i;
    }

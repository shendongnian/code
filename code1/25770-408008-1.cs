    public class SomeClass
    {
        static void foo(int x) { }
        static void foo(string s) { }
        static void bar<T>(Action<T> f){}
        static void barz(Action<int> f) { }
        static void test()
        {
            Action<int> f = foo;
            bar(f);
            barz(foo);
            bar(foo);
            //these help the compiler to know which types to use
            bar<int>(foo);
            bar( (int i) => foo(i));
        }
    }

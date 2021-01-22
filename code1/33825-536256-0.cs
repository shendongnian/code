    class Foo<T> where T : struct {
        static Foo() {
            if (!typeof(T).IsEnum) {
                throw new InvalidOperationException("Can only use enums");
            }
        }
        public static void Bar() { }
    }
    enum MyEnum { A, B, C }
    static void Main() {
        Foo<MyEnum>.Bar(); // fine
        Foo<int>.Bar(); // error
    }

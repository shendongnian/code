    class MyClass
    {
    public enum Foo { Bar, Baz }
    public static void MyMethod(params Foo[] foos) {}
    public static void TestMethod()
    {
        MyMethod();
        MyMethod(Foo.Bar);
        MyMethod(Foo.Baz);
        MyMethod(Foo.Bar, Foo.Baz);
    }
}

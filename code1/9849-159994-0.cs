    public class Foo
    {
         public static bool DoSomething() { return false; }
    }
    public class Bar : Foo
    {
         public new static bool DoSomething() { return true; }
    }

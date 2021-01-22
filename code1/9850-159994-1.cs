    public class Foo
    {
         public bool DoSomething() { return false; }
    }
    public class Bar : Foo
    {
         public new bool DoSomething() { return true; }
    }

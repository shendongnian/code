    public interface IFoo { }
    public interface IFoo<T> : IFoo { }
    public interface IFoo<T, M> : IFoo<T> { }
    public class Foo : IFoo { }
    public class Foo<T> : IFoo { }
    public class Foo<T, M> : IFoo<T> { }
    public class FooInt : IFoo<int> { }
    public class FooStringInt : IFoo<string, int> { }
    public class Foo2 : Foo { }

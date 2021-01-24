    public class Bar<T>
    {}
    public interface IDev
    {}
    public abstract class Foo<T> : Bar<T> where T : IDev
    {}
    public class Fizz : Foo<Fizz>, IDev
    {}

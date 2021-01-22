    public interface TestInterface<T>
    {
        T MethodHere();
    }
    public class Test1 : TestInterface<string>
    ... // body as before
    public class Test2 : TestInterface<int>
    ... // body as before

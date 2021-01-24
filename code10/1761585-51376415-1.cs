    public class Test<T>
    {
        public T Something { get; private set; }
        
        public Test(T something) {
            Something = something;
        }
    
    }
    // in some static class
    public static Test<NewT> Cast<T, NewT>(this Test<T> test) where T : NewT
    {
        return new Test<NewT>(test.Something);
    }

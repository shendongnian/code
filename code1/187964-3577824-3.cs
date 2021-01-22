    public class Foo
    {
        public Foo()
        {
            Progress = new Observable<T>();
        } 
    
        public Observable<T> Progress { get; private set; }
    }

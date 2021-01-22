    public class MyClass
    {
        // These were not added until .Net 3.5
        public delegate void Action();
        public delegate TResult Func<TResult>();
        public delegate TResult Func<TResult,T>(T arg);
        public delegate TResult Func<TResult,T1, T2>(T1 arg1, T2 arg2);
        public void DoSomething(Func<int> callback) {
            ...
        }
    }

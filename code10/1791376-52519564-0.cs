    class Program
    {
        public event Func<Exception, Task> Closed;
        static void Main(string[] args)
        {
            Program p = new Program();
            IObservable<Unit> closedObservable = Observable.Create<Unit>(
                observer =>
                {
                    Func<Exception, Task> handler = ex =>
                    {
                        observer.OnNext(Unit.Default);
                        return Task.CompletedTask;
                    };
                    p.Closed += handler;
                    return () => p.Closed -= handler;
                });
        }
    }

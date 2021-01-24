    class Useful<TDisposable> where TDisposable : IDisposable
    {
        private Func<TDisposable> Factory { get; }
        public Useful(Func<TDisposable> factory) 
        {
           this.Fatory = factory;
        }
        public TResult SafeDo<TResult>(Func<TDisposable, TResult> operation) 
        {
           using (TDisposable obj = this.Factory())
           {
               return operation(obj);
           }
        }
    }

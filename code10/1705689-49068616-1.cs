    public static class Extensions {
        public static TResult GetThenDispose<TDisposable, TResult>(
            this TDisposable d, 
            Func<TDisposable, TResult> func) 
                where TDisposable : IDisposable {
            using (d) {
                return func(d);
            }
        }
    }

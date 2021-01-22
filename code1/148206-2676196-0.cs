        public sealed class DisposableClass : IDisposable
        {
            private DisposableClass()
            {
            }
            public void Dispose()
            {
                //Dispose...
            }
            public static void DoSomething(Action<DisposableClass> doSomething)
            {
                using (var disposable = new DisposableClass())
                {
                    doSomething(disposable);
                }
            }
        }

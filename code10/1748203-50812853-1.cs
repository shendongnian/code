    public static void Foo()
    { 
            var result = DoWithWaitingForm(() =>
            {
                Thread.Sleep(5000);
                return Task.FromResult(42);
            });
            var result2 = DoWithWaitingForm(() => Foo().Result);
        }
        // helper to deduce the type of the generic parameter for WaitingForm
        public static Task<T> DoWithWaitingForm<T>(Func<T> operation)
        {
            var form = new WaitingForm<T>
            {
                Task = Task.Run(operation),
            };
            form.ShowDialog();
            return form.Task;
        }
        // example async function
        async static Task<int> Foo()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return Task.FromResult(42);
            });
        }

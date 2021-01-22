        public static void RunAsync<T1, T2, TResult>(Func<T1, T2, TResult> function, T1 param1, T2 param2, Action<TResult> callback)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                e.Result = function(param1, param2);
            };
            worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                TResult result = (TResult)e.Result;
                callback(result);
            };
            worker.RunWorkerAsync();
        }

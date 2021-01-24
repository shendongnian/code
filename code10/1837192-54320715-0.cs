        void Execute(Action action, TimeSpan timeout)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);
            try
            {
                Task.Run(action, cts.Token).Wait();
            }
            catch (TaskCanceledException e)
            {
                //here you know the task is cancelled due to timeout
            }
        }

        Task<object> RunTestWithDispatcher(Action testAction)
        {
            var taskCompletion = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                var operation = Dispatcher.CurrentDispatcher.BeginInvoke(testAction);
                operation.Completed += (s, e) =>
                {
                    Dispatcher.CurrentDispatcher.ShutdownFinished += (s2, e2) =>
                    {
                        taskCompletion.TrySetResult(null);
                    };
                    // Dispatcher finishes queued tasks before shuts down at idle priority
                    Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.ApplicationIdle);
                };
                Dispatcher.Run();
            });
            thread.IsBackground = true;
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
            return taskCompletion.Task;
        }

        Task<object> RunTestWithDispatcher(Action testAction)
        {
            var thread = new Thread(() =>
            {
                var operation = Dispatcher.CurrentDispatcher.BeginInvoke(testAction);
                operation.Completed += (s, e) =>
                {
                    // Dispatcher finishes queued tasks before shuts down at idle priority (important for TransientEventTest)
                    Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.ApplicationIdle);
                };
                Dispatcher.Run();
            });
            thread.IsBackground = true;
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

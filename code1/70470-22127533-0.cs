        internal Thread CreateDispatcher()
        {
            var dispatcherReadyEvent = new ManualResetEvent(false);
            var dispatcherThread = new Thread(() =>
            {
                // This is here just to force the dispatcher 
                // infrastructure to be setup on this thread
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { }));
                // Run the dispatcher so it starts processing the message 
                // loop dispatcher
                dispatcherReadyEvent.Set();
                Dispatcher.Run();
            });
            dispatcherThread.SetApartmentState(ApartmentState.STA);
            dispatcherThread.IsBackground = true;
            dispatcherThread.Start();
            dispatcherReadyEvent.WaitOne();
            SynchronizationContext
               .SetSynchronizationContext(new DispatcherSynchronizationContext());
            return dispatcherThread;
        }

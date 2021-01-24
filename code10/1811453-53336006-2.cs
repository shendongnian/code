    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DoSomething().ContinueWith((task) =>
            {
                bool k = task.Result;
    
                // use the result
            },
    
            // TaskScheduler argument is needed only if the continuation task
            // must run on the UI thread (eg. because it access UI elements).
            // Otherwise this argument can be omitted.
            TaskScheduler.FromCurrentSynchronizationContext());
        // Method can exit before DoSomething().Result becomes
        // available, which keep UI responsive
    }

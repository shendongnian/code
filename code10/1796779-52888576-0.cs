    Application.Current.Suspending += OnSuspending;
    Application.Current.Resuming += OnResuming;
    
    private void OnResuming(object sender, object e)
    {
        // Reinitialize all watchers for HID
        // Subscribe to all necessary events
    }
    
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        // Remove all watchers for HID
        // Unsubscribe from all events
        // Dispose all active HID devices
    }

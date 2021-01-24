    public static async Task DispatchToUI(Action action, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal)
    {
        if (CoreApplication.MainView.CoreWindow.Dispatcher.HasThreadAccess)
        {
            action();
        }
        else
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(priority, new DispatchedHandler(action));
        }
    }

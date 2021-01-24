    internal async Task<U> ShowAsync<T, U>(IDictionary<string, object> arguments = null, bool animated = true) where T : IDialogView where U : IDialogResult
    {
        var completionSource = new TaskCompletionSource<U>();
        try
        {
            var page = (IDialogView)Activator.CreateInstance<T>();
            // Hook up event handlers so when either the Complete/Error is fired then we dismiss and pass the result back to the caller.
            page.ResultChanged += (sender, e) =>
            {
                // Hide the modal view.
                this.DismissAsync();
                // Do we need to perform a safety check when converting?
                completionSource.SetResult((U)e.Value);
            };
                
            // Pass in any arguments to the view.
            page.SetArguments(arguments);
            // Display the view and wait.
            await this.navigation.PushModalAsync((Page)page, animated);
            // Return the result of the view.
            return await completionSource.Task;
        }
        catch (Exception ex)
        {
            LogService.Error($"Unable to ShowAsync for view: {typeof(T).Name}", ex);
            completionSource.SetException(ex);
        }
        return default(U);
    }
    internal interface IDialogView
    {
        event EventHandler<EventArgs<IDialogResult>> ResultChanged;
        void SetArguments(IDictionary<string, object> arguments);
    }
    internal interface IDialogResult
    {
    }

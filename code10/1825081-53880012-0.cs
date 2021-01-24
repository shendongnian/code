    private IAsyncOperation<string> GetAsyncOperation()
    {
        return AsyncInfo.Run<string>(
           (token) => // CancellationToken token
               Task.Run<string>(
                   () =>
                   {
                       token.WaitHandle.WaitOne(3000);
                       token.ThrowIfCancellationRequested();     
                       return "hello";
                   },
                   token));
    }
    private IAsyncOperation<string> operation;
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            operation = GetAsyncOperation();
            var res = await operation;
        }
        catch (Exception)
        {
    
            System.Diagnostics.Debug.WriteLine("method end");
        }
    
    }
    private void Cancel_Button_Click(object sender, RoutedEventArgs e)
    {
        operation?.Cancel();
    }

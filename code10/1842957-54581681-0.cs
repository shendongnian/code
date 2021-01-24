    public void ShowMessageBoxAsync(string message, Action afterAction)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            // See "Chaining Tasks ..." link. Use "afterAction" as "continuation".
            ... DisplayAlert("Error", message, "OK", "Cancel") ...
        });
    }

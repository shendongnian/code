    private async Task SetMessageViewAsync()
    {
       vm.Msg1 = "ABC";
       await Task.Delay(500, cts.Token);
    }
    // some actions
    if (App.pauseCard == true)
    {
        await SetMessageViewAsync();
        return;
    }
    // some actions

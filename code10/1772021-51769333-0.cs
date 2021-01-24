    protected override void OnAppearing()
    {
        Task.Run( () => LoadData());
        base.OnAppearing();
    }
    
    private async void LoadData()
    {
        HttpClient httpClient = new HttpClient();
        var obj = await httpClient.GetAsync("//Api//");
        if (obj.IsSuccessStatusCode)
        {
            // If you need to set properties on the view be sure to use MainThread
            // otherwise you won't see it on the view.
            Device.BeginInvokeOnMainThread(() => Name = "your text";);
        }
    }

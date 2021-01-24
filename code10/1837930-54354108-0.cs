    private bool isCancelled = false;
    
    private async void GetData()
    {
        await Task.Delay(5000);
        if (!isCancelled)
            MainPage.actualPage.PushAsync(new Page03());
    }
    
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        isCancelled = true;
        App.Current.MainPage = new Page01();
    }

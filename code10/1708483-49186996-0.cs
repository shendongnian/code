    private void Start()
    {
        // invoke
        Device.BeginInvokeOnMainThread(SomeMethod);
    }
    
    private async void SomeMethod()
    {
        try
        {
            // await method
            await SomeAsyncMethod();
        }
        catch (Exception e) // handle whatever exceptions you expect
        {
            //Handle exceptions
        }
    }
    
    private async Task SomeAsyncMethod()
    {
        // in this case lets push a new page
        await Navigation.PushModalAsync(new ContentPage());
    }

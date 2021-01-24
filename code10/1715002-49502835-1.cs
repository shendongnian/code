    protected async override Task OnAppearing()
    {
        await viewmodel.OnAppearing();
        base.OnAppearing();
        System.Diagnostics.Debug.WriteLine("*****Here*****");
    }

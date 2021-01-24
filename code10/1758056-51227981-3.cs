    public MyPage() {
        //Subscribing to our event here
        FabClicked += OnFabClicked;
        //FABaddT is already defined in the XAML so just setting the delegate here
        FABaddT.Clicked = (sender, args) => {
            //Raising the event here and passing sender and event arguments on
            FabClicked(sender, args);
        };
    }
    private event EventHandler FabClicked = delegate { };
    private async void OnFabClicked(object sender, EventArgs args) {
        var page = new AddTransactionPage();
        await Navigation.PushAsync(page);
    }

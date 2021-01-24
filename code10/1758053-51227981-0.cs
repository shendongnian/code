    public MyPage() {
        //FABaddT is already defined in the XAML so just setting event handler here    
        FABaddT.Clicked = async (sender, args) => {
            var page = new AddTransactionPage();
            await Navigation.PushAsync(page);
            //...
        };
    }

    public async Task printMethod()
    {
        SecondViewModel mySeocViewModel = await SecondViewModel.CreateAsync(myParameter);
        SecondView mySecondView = new SecondView();
        mySecondView.DataContext = mySeocViewModel;
    }

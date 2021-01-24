    if (sitecode != null)
    {
        if (sitecode.Id != null)
        {
            MainPage mainPage = new MainPage();
            mainPage.SelectedItem = mainPage.Children[1];
            MainPage = mainPage;
        }
        else
        {
            MainPage = new LoadScreenPage();
        }
    }
    else
    {
        MainPage = new LoadScreenPage();
    }

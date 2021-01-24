    public MainPage()
    {
        var menuPage = new MenuPage();
        Master = menuPage;
        Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListItemsPage));
        menuPage.ListView.ItemSelected += OnMenuItemSelected
    }
    OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = e.SelectedItem as MasterPageItem;
        if (item != null) {
            Detail = new NavigationPage ((Page)Activator.CreateInstance (item.TargetType));
            masterPage.listView.SelectedItem = null;
            IsPresented = false;
        }    
    }

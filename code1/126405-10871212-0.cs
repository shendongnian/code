    Load the Tab content dynamically on selection, for UI to be responsive, use code similar to below:
     private void tab_Selected(object sender, EventArgs e)
    {
       //Get the selected tab
     Action loadTab = delegate
    {
      LoadSelectedTab(tabItem);
    }
    Dispatcher.BeginInvoke(DispatcherPriority.Background, loadTab);
    }
    public void LoadSelectedTab(TabItem item)
    {
      item.Content = new EmployeeTab();
      .....
    }
    
    The UI repsonse will be very fast, UI start loading very fast and you don't see pause for any delays

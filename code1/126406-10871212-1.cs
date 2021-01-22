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
    

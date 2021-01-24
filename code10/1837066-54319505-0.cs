       UIBarButtonItem backBtn = new UIBarButtonItem();
       backBtn.Title = "back";
       backBtn.Style = UIBarButtonItemStyle.Plain;
       this.NavigationItem.LeftBarButtonItem = backBtn;
    
       backBtn.Clicked += (sender, e) =>
       {
           // 1 here is an example, it should be the index of your EvevtTableViewControll
           NavigationController.TabBarController.SelectedIndex = 1;
           NavigationController.PopToRootViewController(true);
       };

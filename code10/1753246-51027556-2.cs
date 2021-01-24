    var label = new UILabel();
    //get the default title
    label.Text =  NavigationController.NavigationBar.TopItem.Title; 
    label.TextAlignment = UITextAlignment.Left;
    label.SizeToFit();
    //empty the default title (try with empty string or null if empty doesnt work)
    NavigationController.NavigationBar.TopItem.Title = "";    
    NavigationController.NavigationBar.TopItem.LeftBarButtonItem = new UIBarButtonItem(label);

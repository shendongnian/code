    var label = new UILabel();
    //this is the variable containing the title you need to pass it as a bindable property
    label.Text = title; 
    label.TextAlignment = UITextAlignment.Left;
    label.SizeToFit();
    NavigationController.NavigationBar.TopItem.LeftBarButtonItem = new UIBarButtonItem(label);

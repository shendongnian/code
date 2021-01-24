    UIButton button = new UIButton(new CGRect(100, 300, 100, 50));
    button.SetTitle("PurpleFruit",UIControlState.Normal);
    button.SetTitleColor(UIColor.White, UIControlState.Normal);
    button.BackgroundColor = UIColor.Blue;
    button.TouchUpInside += (sender, e) =>
      {
       NSDictionary dic =NSDictionary.FromObjectAndKey(new NSString("value"),new NSString(button.TitleLabel.Text)) ;
       NSNotification notification = NSNotification.FromName("ChangeValue",null,dic); //pass the string as a parameter
       NSNotificationCenter.DefaultCenter.PostNotification(notification);
              
      };

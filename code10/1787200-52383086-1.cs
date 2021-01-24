    public override void ViewWillAppear(bool animated)
      {
        base.ViewWillAppear(animated);
        
        NSNotificationCenter.DefaultCenter.AddObserver(this,new Selector("ChangeValue:"),new NSString("ChangeValue") ,null);
      }
     [Export("ChangeValue:")]
     public void ChangeValue(NSNotification notification)
       {
         Console.Write(notification.UserInfo.ObjectForKey(new NSString ("value")));
         // now you can change the label.text 
       } 

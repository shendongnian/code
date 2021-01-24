    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
      base.OnElementChanged(e);
      if(e.NewElement!=null)
      {
        page = (MainPage)e.NewElement;
      }
      else
      {
        page = (MainPage)e.OldElement;
      }
      if (this.Element != null)
      {
         UITabBarController tabbar = (UITabBarController)this.ViewController;
         tabbar.ShouldSelectViewController += SelectViewController;
      }
    }
    public  bool SelectViewController(UITabBarController tabBarController, UIViewController viewController)
    {
      if(viewController==this.ViewControllers[1])
      {
        //do something you want 
        return false;
      }
      else
      {
        return true;
      }
    } 
 

    private xxx page;//xxx is your tabbedPage in forms
  
    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
      base.OnElementChanged(e);
      if(e.NewElement!=null)
      {
        page = (xxx)e.NewElement;
      }
      else
      {
        page = (xxx)e.OldElement;
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
 

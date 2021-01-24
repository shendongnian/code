    UIViewController lastViewController;
    private void addSubsFrom(string viewControllersIdentifier)
    {
        if (lastViewController != null)
        {
            lastViewController.View.RemoveFromSuperview();
            lastViewController.RemoveFromParentViewController();
        }
    
        var viewController = Storyboard.InstantiateViewController(viewControllersIdentifier);
        viewController.View.Frame = View.Bounds;
    
        View.AddSubview(viewController.View);
        AddChildViewController(viewController);
    
        lastViewController = viewController;
    }
    
    public void segueIdentifireRecievedFromParent(int selectedRow)
    {
        if (selectedRow == 0)
        {
            addSubsFrom("TestAVC");
    
        }
        else if (selectedRow == 1)
        {
            addSubsFrom("TestBVC");
        }
    }

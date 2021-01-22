    private Control GetControl()
    {
        string dynamicCtrl = CurrentItem.DynamicControl;
        string path = SomeClass.DynamicControls[dynamicCtrl];
        Control ctrl = LoadControl(path);    
        return ctrl;
    }

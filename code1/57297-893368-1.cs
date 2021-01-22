    internal void Setup(MyBusinessObject obj)
    {    
        Debug.Assert(obj != null);
        MenuObject menu = MenuHelper.GetMenu(obj.State);    
        Debug.Assert(MenuContainer != null);
        if(obj == null)        
            MenuContainer.Visible = false;    //other code
    }

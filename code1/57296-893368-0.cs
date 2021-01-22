    internal void Setup(MyBusinessObject obj)
    {    
        MenuObject menu = MenuHelper.GetMenu(obj.State);    
    
        if(obj == null)        
            MenuContainer.Visible = false;    //other code
    }

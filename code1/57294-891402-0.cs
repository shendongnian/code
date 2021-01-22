    internal void Setup(MyBusinessObject obj)
    {
        if(obj == null)
            MenuContainer.Visible = false;
        else
            MenuObject menu = MenuHelper.GetMenu(obj.State);
    }

    public override void OnActionModeStarted(ActionMode mode)
    {
        IMenu menu = mode.Menu;
        menu.Add("To Notes");
        menu.GetItem(0).SetOnMenuItemClickListener(new MyMenuItemOnMenuItemClickListener(this,mode));
    
        base.OnActionModeStarted(mode);
    }
    

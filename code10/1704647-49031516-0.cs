    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
    
        if (ViewState["Radio1"] != null)
            Radio1.Text = (int)ViewState["Radio1"];
        ...
    }
    
    protected override object SaveViewState()
    {
        ViewState["Radio1"] = Radio1.Text;
        ...
    
        return base.SaveViewState();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    
        if (!Page.IsInPostBack)
        {
            SetFieldVisibility();
            ClearFields();
        }
    }

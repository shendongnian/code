    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (_ContentTemplate != null)
             _ContentTemplate.InstantiateIn(BodyControlSpace); 
    } 

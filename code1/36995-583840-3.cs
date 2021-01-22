    public KeyValuePair<Foo,List<Bar>> DataItem
    {
        get; set;
    }
    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);
     
        lbName.Text = DataItem.Key.Name;
        ddlListOfBars.DataTextField = "ItemName";
        ddlListOfBars.DataValueField = "ItemValue";
        ddlListOfBars.DataSource = DataItem.Value;
        ddlListOfBars.DataBind();   
    }

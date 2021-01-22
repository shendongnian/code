    public delegate void DataBindDelegate();
    public DataBindDelegate BindData = new DataBindDelegate(DoDataBind);
    public void DoDataBind()
    {
        DataBind();
    }

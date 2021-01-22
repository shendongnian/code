    public MusicItem CurrentItem { get; private set;}
    
    protected void Item_DataBound(object sender, RepeaterItemEventArgs e)
    {
       CurrentItem = (MusicItem) e.Item.DataItem;
    }

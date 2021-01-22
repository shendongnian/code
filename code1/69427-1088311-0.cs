    public delegate void IndexChangeEventHandler(object sender, EventArgs e); 
    public event IndexChangeEventHandler SelectedIndexChanged =  delegate { };
    //this is in your composite control, handling ddl's index change event
    protected void DDL_SelectedIndexchanged(object sender, EventArgs e)
    {
        SelectedIndexChanged(this, e);
    }

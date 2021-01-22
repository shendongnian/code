    private Literal litControlTitle;
    protected void litControlTitle_Init(object sender, EventArgs e)
    {
        litControlTitle = (Literal) sender;
    }
    protected void lv_DataBound(object sender, EventArgs e)
    {
        litControlTitle.Text = "Title...";
    }

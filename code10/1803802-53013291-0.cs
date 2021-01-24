    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (ListViewDataItem item in ListView1.Items)
        {
            LinkButton lb = item.FindControl("pauseSubBtn") as LinkButton;
            ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(lb);
        }
    }

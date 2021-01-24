    protected void autoRefreshNotifications(object sender, EventArgs e)
    {
        //find the gridview in the contentplaceholder
        GridView gv = ContentPlaceHolder1.FindControl("folderContentGrid") as GridView;
        //loop all the rows in the gridview
        foreach (GridViewRow row in gv.Rows)
        {
            //find the linkbutton in the row using findcontrol
            LinkButton lnkDownloadBtn = (LinkButton)row.FindControl("lnkDownloadBtn");
            if (lnkDownloadBtn != null)
            {
                //bind the postback trigger to the linkbutton
                ScriptManager mgr = ScriptManager.GetCurrent(this.Page);
                mgr.RegisterPostBackControl(lnkDownloadBtn);
            }
        }
    }

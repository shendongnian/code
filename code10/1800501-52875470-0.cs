    protected void rpt_Adverts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Panel pnl = e.Item.FindControl("pnlAds") as Panel;
        if (url.Length > 0)
        {
            pnl.Controls.Add(hlAdvert);
        }
        else
        {
            pnl.Controls.Add(imgAd);
        }
    }

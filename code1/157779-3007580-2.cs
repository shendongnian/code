    void rptTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        XElement item = (XElement)e.Item.DataItem;
        HyperLink lnkTest = (HyperLink)e.Item.FindControl("lnkTest");
        lnkTest.NavigateUrl = "Page?id=" + item.Attribute("id").Value;
        lnkTest.Text = item.Attribute("name").Value;
    }

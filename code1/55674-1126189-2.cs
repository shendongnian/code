    protected override void OnPreRender(EventArgs e)
    {
        base.OnLoad(e);
        List<string> strList = new List<string>();
        strList.Add("1");
        rptBugStatus.DataSource = strList;
        rptBugStatus.DataBind();
    }
    protected void rptBugStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblBugStatus = e.Item.FindControl("lblBugStatus") as Label;
            // have added this just so we are actually setting the text property on the bug status
            // - i have assumed you do this.
            lblBugStatus.Text = e.Item.DataItem.ToString();
            if (lblBugStatus.Text.Equals("1"))
            {
                lblBugStatus.Text = lblBugStatus.Text + "Under arbete";
            }
            else if (lblBugStatus.Text.Equals("0"))
            {
                lblBugStatus.Text = "Fixad";
            }
        }
    }

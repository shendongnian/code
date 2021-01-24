    protected void AddItemClick(object sender, EventArgs e)
    {
        List<UserEntry> ue;
        if (ViewState["items"] == null)
        {
            ue = new List<UserEntry>();
        }
        else
        {
            ue = (List<UserEntry>)ViewState["items"];
        }
        ue.Add(new UserEntry());
        ViewState["items"] = ue;
        ListItems.DataSource = ue;
        ListItems.DataBind();
    }

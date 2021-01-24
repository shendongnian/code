    protected void Page_Load(object sender, EventArgs e)
    {
        var list = (WebUserControl1)LoadControl("~/WebUserControl1.ascx");
        list.ID = "MyUserControl";
        Panel1.Controls.Add(list);
        list._ARepeater.DataSource = source;
        list._ARepeater.DataBind();
    }

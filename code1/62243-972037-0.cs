    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        list.Add("Teststring");
        this.GridView.DataSource = list;
        this.GridView.DataBind();
    }

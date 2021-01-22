    protected void Page_Load(object sender, EventArgs e)
    {
        if(!isPostback)
        {
        GridView2.DataSource = new Person(id).GetDataSet();
        GridView2.DataBind();
        }
    }

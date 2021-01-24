    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
        GridView1.DataSource = GetData("SELECT ContactName, Country FROM Customers");
        GridView1.DataBind();
    }
    }

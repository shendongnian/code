    protected void Page_Load(object sender, EventArgs e)
    {
        GridTest.DataSource = new List<int>{1, 2, 3};
        GridTest.DataBind();
    }
    protected string GetValue(int ID)
    {
        return "Value from Execute Scalar " + ID;
    }

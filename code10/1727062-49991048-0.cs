    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = SqlDataSource2;
            DataList1.DataBind();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataList1.DataSource = SqlDataSource1;
        DataList1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //as a query
            DataTable dt = LoadDataFromDB("select top 10 * from mytable");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //or stored procedure
            DropDownList1.DataSource = LoadDataFromDB("mysp 1, 2");
            DropDownList1.DataTextField = "columnA";
            DropDownList1.DataValueField = "columnB";
            DropDownList1.DataBind();
        }
    }

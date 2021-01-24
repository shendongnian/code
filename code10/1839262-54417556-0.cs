    protected void Page_Load(object sender, EventArgs e)
    {
        //normally you would bind here
        if (IsPostBack == false)
        {
            GridView1.DataSource = source;
            GridView1.DataBind();
        }
        //but when using dynamic control inside a gridview, bind here
        GridView1.DataSource = source;
        GridView1.DataBind();
    }

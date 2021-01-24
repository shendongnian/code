     protected void Page_Load(object sender, EventArgs e)
    {
    if(!IsPostBack)
    {
        SqlConnection conn = new DB_Connection().getConnection();
        SqlDataAdapter uni_adapter = new SqlDataAdapter("select uni_id,uni_name from universities", conn);
        DataSet ds = new DataSet();
        uni_adapter.Fill(ds);
    
        uni_name.DataSource = ds;
        uni_name.DataTextField = "uni_name";
        uni_name.DataValueField = "uni_id";
        uni_name.DataBind();
    }
    }

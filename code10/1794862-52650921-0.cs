    protected void Page_Load(object sender, EventArgs e)
    {
    	if( !Page.IsPostBack )
    	{
    		LoadData();
    	}
    }
    protected void LoadData()
    {
    	SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConnectionStringGlobal;
        conn.Open();
        string query = "SELECT * FROM Clients";
        SqlCommand cmd = new SqlCommand(query, conn);
    
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        conn.Close();
    
        GridView2.DataSource = dt;
        GridView2.DataBind();	
    }

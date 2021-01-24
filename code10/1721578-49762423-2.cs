    protected void Page_Load(object sender, EventArgs e)
    {
        headerDate.InnerText = DateTime.Now.ToString();
        DataTable dt = GetData();
        // now use it as needed
        
       
    }
    private DataTable GetData()
    {
       string strSQLConn = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
       SqlConnection sqlConn = new SqlConnection(strSQLConn);
       DataTable dt = new DataTable();
       SqlCommand command = new SqlCommand("getNetEvents", sqlConn);
       command.CommandType = CommandType.StoredProcedure;
       sqlConn.Open();
       SqlDataAdapter da = new SqlDataAdapter(command);
       da.Fill(dt);
        sqlConn.Close();
       return dt;
    }

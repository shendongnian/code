    protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection UsageLogConn = new MySqlConnection("Server=localhost;UID=root;Password=;database=productactivation");
            UsageLogConn.Open();//open connection
    
            string sql = "select * from sales";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sql, UsageLogConn);
            MySqlDataAdapter mySQLadapter = new MySqlDataAdapter(cmd);
            mySQLadapter.Fill(ds);
            Chart1.DataSource = ds;
    
            // set series members names for the X and Y values 
            Chart1.Series["Series1"].XValueMember = "title_id";
            Chart1.Series["Series1"].YValueMembers = "qty";
            Chart1.Series["Series2"].XValueMember = "title_id";
            Chart1.Series["Series2"].YValueMembers = "qty";
            UsageLogConn.Close();
            // data bind to the selected data source
            Chart1.DataBind();
    
    
            cmd.Dispose();
    
        }

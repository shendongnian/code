    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int count = 0; count < gvTest.Rows.Count; count++ )
            {
                CheckBox chkSelect = (CheckBox)gvTest.Rows[count].FindControl("chkDel");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked == true)
                    {
                        //Receiveing RegID from the GridView
                        int RegID = Int32.Parse((gvTest.Rows[count].Cells[1].Text).ToString());
    		    
                        object result = DeleteRecord(RegID); //DeleteRecord Function will delete the record                   
                    }
                }
            }
            PopulateGrid(); //PopulateGrid Function will again populate the grid
        }
    
       public void DeleteRecord(int RegId)
        {
            string connectionPath = "Data Source=<your data source>;Initial Catalog=<db name>;Integrated Security=True;userid='test';pwd='test'";
            string command = "";
    	SqlConnection connection = new SqlConnection(@connectionPath);
            command = "delete from tblname where id = " +  RegId 
    	try
    	{
    		connection.Open();
    		SqlCommand cmd = new SqlCommand(command, connection);
    		cmd.ExecuteNonQuery();
    	}
    	catch (SqlException sqlExcep) {} 
    	finally
    	 {
    		connection.Close();
    	 }
        }
    
        public void PopulateGrid()
        {
            
            DataTable dt = new DataTable();
    	dt = GetRecord();
    	if(dt !=null && dt.rows.count>0)
    	{
                 gvTest.DataSource = dt;
                 gvTest.DataBind();
    	}
    		
        }
    
        public DataTable GetRecord()
        {
           string connectionPath = "Data Source=<your data source>;Initial Catalog=<db name>;Integrated Security=True;userid='test';pwd='test'";
            string command = "";
            SqlDataAdapter adapter = new SqlDataAdapter();			
    	SqlConnection connection = new SqlConnection(@connectionPath);
    	command = "Select * from tblname" ;
    	connection.Open();
    	SqlCommand sqlCom = new SqlCommand(command, connection);
    	adapter.SelectCommand = sqlCom;
    	DataTable table = new DataTable();	
    	adapter.Fill(table);
    	return table;
        }

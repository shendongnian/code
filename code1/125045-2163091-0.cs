    DataSet ds = new DataSet();
    
    using (SqlConnection conn = YourConnectionFactory.GetConnection())  
    {  
    SqlCommand objComm = DBHelper.CreateStoredProc("YourStoredProcedure",
    conn);  
    SqlDataAdapter adapt = new SqlDataAdapter(objComm);  
    adapt.Fill(ds, TableName);  
    conn.Close();  
    }  
      
    DataTable dt = ds.Tables[0];  
    for (int a=dt.Rows.Count-1; a>= 0; a--)  
    {  
    // check and insert as necessary  
    }  
    
    YourControl.DataSource = ds;  
    YourControl.DataBind();  

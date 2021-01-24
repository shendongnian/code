    private void getMRF_No()
    {
         string year = DateTime.Now.Year.ToString();
    
        //you can add number within SQL, it is not recommend to use IsNull, you can remove 
        //IsNUll(MRF_NO,0) and just use MRF_NO, if you think MRF_NO will never be NULL
        string query = "SELECT TOP 1 IsNUll(MRF_NO,0) +1 [MRF_NO] FROM MRF_DETAILS ORDER BY MRF_NO DESC"; 
    
    
    	var dt = new DataTable();
        using(var sqlAdapter = new SqlDataAdapter(query, new SqlConnection(conn)))
    	{
    	 	sqlAdapter.Fill(dt);
    	}
    	
    	var mrfNo= (dt.Rows.Count > 0) ? Int64.Parse(dt.Rows[0][0].ToString()) : 1;	
    		
    	//year is already string,do not have to convert and ToString method of Int can format 
        // your number
    	txtMRFNo.Text = year + mrfNo.ToString("000");
    }

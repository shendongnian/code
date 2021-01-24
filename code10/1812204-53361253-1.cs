    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
    	var sqlStr = new System.Text.StringBuilder();
        sqlStr.AppendLine("select * from question where 1 = 1 ");
    	if(!string.IsNullOrEmpty(txtBxSearch.Text)){
    		sqlStr.AppendLine(" AND questioncat = @questioncat ");
             Parameters.Add(new SqlParameter("@questioncat", txtCondition1.Text));
    		//and add parameter for your command.
    	}
    		
    	if(!string.IsNullOrEmpty(txtBxSearch1.Text)){
    		sqlStr.AppendLine(" AND questioncat1 = @questioncat1 ");
            Parameters.Add(new SqlParameter("@questioncat1", txtCondition2.Text));
    		//and add parameter for your command.
    	}
        //.... do your SQL execute.
    
    }

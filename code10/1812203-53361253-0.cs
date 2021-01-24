    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
    	var sqlStr = new System.Text.StringBuilder();
        sqlStr.AppendLine("select * from question where 1 = 1 ");
    	if(!string.IsNullOrEmpty(txtBxSearch.Text)){
    		sqlStr.AppendLine(" AND questioncat = @questioncat ");
    		//and add parameter for your command.
    	}
    		
    	if(!string.IsNullOrEmpty(txtBxSearch1.Text)){
    		sqlStr.AppendLine(" AND questioncat1 = @questioncat1 ");
    		//and add parameter for your command.
    	}
        //.... do your SQL execute.
    
    }

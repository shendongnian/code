    		string rawUserInput = "Queso Cabrales1";
    		#region  BadExample
    		//string sql = "delete from Products where ProductName = " + rawUserInput;
    		////QueryCommand objQueryCommand = new QueryCommand(sql, Product.Schema.Provider.Name);
    		////DataService.ExecuteQuery(objQueryCommand);
    		#endregion BadExample
    
    		#region BetterExample
    		// Should be:
    		
    		string sql = "update Products set ProductName =  @ProductName where ProductName='Queso Cabrales'";
    		QueryCommand objQueryCommand = new QueryCommand(sql, Northwind.Product.Schema.Provider.Name);
    		objQueryCommand.AddParameter("@ProductName" , rawUserInput, DbType.String);
    		DataService.ExecuteQuery(objQueryCommand);
    
    
    		panGvHolder.Controls.Clear();
    
    		Query qry = Northwind.Product.CreateQuery();
    		qry.Columns.AddRange(Northwind.Product.Schema.Columns);
    		qry.WHERE("UnitPrice > 15").AND("UnitsInStock < 20 ");
    		//WHERE("UnitPrice > 15").AND("UnitsInStock < 30 ");
    		#endregion BetterExample
    
    		#region PresentResultsReplaceResponseWriteWithConsole.WriteLineForConsoleApp
    		using (IDataReader rdr = qry.ExecuteReader())
    		{
    			Response.Write("<table>");
    			while (rdr.Read())
    			{
    				Response.Write("<tr>");
    				for (int i = 0; i < rdr.FieldCount; i++)
    				{
    					Response.Write("<td>");
    					Response.Write(rdr[i].ToString() + " ");
    					Response.Write("<td>");
    				} //eof for 
    				Response.Write("</br>");
    				Response.Write("</tr>");
    			}
    			Response.Write("<table>");
    		}
    		#endregion PresentResultsReplaceResponseWriteWithConsole.WriteLineForConsoleApp
    
    	} //eof method
 

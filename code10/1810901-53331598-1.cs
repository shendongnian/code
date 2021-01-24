        public void ExtractFormTest()
        {
    	using (ShimsContext.Create())
    	{
    		#region FakeIt
    		System.Data.SqlClient.Fakes.ShimSqlConnection.AllInstances.Open = (SqlConnection sqlConnection) =>
    		{
    			Console.WriteLine("Opened a session with Virtual Sql Server");
    		};
    	
    		System.Data.SqlClient.Fakes.ShimSqlConnection.AllInstances.Close = (SqlConnection sqlConnection) =>
    		{
    			Console.WriteLine("Closed the session with Virtual Sql Server");
    		};
    	
    		System.Data.SqlClient.Fakes.ShimSqlCommand.AllInstances.ExecuteNonQuery = (SqlCommand sqlCommand) =>
    		{
    			if (sqlCommand.CommandText.ToLower().Contains("truncate table"))
    			{
    				Console.WriteLine("Ran " + sqlCommand.CommandText + " at Virtual Sql Server");
    				return 1;
    			}
    			
    			return 0;
    		};
    	
    		System.Data.SqlClient.Fakes.ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (SqlBulkCopy sqlBulkCopy, DataTable datatable) =>
    		{
    			Console.WriteLine("Written #" + datatable.Rows.Count + " records to Virtual Sql Server");
    		};
    	
    		System.Data.Common.Fakes.ShimDbDataAdapter.AllInstances.FillDataSet = (DbDataAdapter dbDataAdapter, DataSet dataSet) =>
    		{
    			var _dataSet = new DataSet();
    			var _dataTable = DataTableHelper.LoadFlatfileIntoDataTable(Path.Combine(dailyEmailFlatfilesDirectory, "Flatfile.txt"), flatfileDelimiter, flatfileDataTableFields, regexPatternMdmValidEmail, traceWriter);
    			if (dbDataAdapter.SelectCommand.CommandText.Equals(mdmSqlStorProcForSpFlatfileData))
    			{
    				while (_dataTable.Rows.Count > 1000)
    					_dataTable.Rows.RemoveAt(0);
    			}
    			else if (dbDataAdapter.SelectCommand.CommandText.Equals(mdmSqlStorProcForStFlatfileData))
    			{
    				while (_dataTable.Rows.Count > 72)
    					_dataTable.Rows.RemoveAt(0);
    			}
    			
    			dataSet.Tables.Add(_dataTable);
    			dataSet = _dataSet;
    			return 1;
    		};
    		#endregion
    	
    		#region Act
    		FormDto formDto = ExtractForm();
    		#endregion
    		
    		#region Assert
    		// Upto the scope of your method and acceptance criteria
    		#endregion
    	}
    }

    public static class DatabaseInfoCollector
    	{		
    		public static System.Collections.Generic.List<string> GetTables(string file)
    		{
    			System.Data.DataTable tables;
    			using(System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file))
    			{
    				connection.Open();
    				tables = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,new object[]{null,null,null,"TABLE"});
    			}
    			System.Collections.Generic.List<string> Tables = new System.Collections.Generic.List<string>();
    			for (int i = 0; i < tables.Rows.Count; i++)
    			{
    				Tables.Add(tables.Rows[i][2].ToString());
    			}
    			return Tables;
    		}		
    		
    		public static System.Collections.Generic.List<string> GetColumnNames(string file, string table)
    		{
    			System.Data.DataTable dataSet = new System.Data.DataTable();			
    			using(System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file))
    			{
    				connection.Open();
    				System.Data.OleDb.OleDbCommand Command = new System.Data.OleDb.OleDbCommand("SELECT * FROM " + table,connection);
    				using(System.Data.OleDb.OleDbDataAdapter dataAdapter = new System.Data.OleDb.OleDbDataAdapter(Command))
    				{
    					dataAdapter.Fill(dataSet);
    				}
    			}
    			System.Collections.Generic.List<string> columns = new System.Collections.Generic.List<string>();
    			for(int i = 0; i < dataSet.Columns.Count; i ++)
    			{
    				columns.Add(dataSet.Columns[i].ColumnName);
    			}
    			return columns;
    		}
    	}

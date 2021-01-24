     public   bool AddColumn(OleDbConnection con, 
					string tableName,string colName,string colType, object defaultValue)
				{
					string query = $"ALTER TABLE {tableName}  ADD COLUMN {colName} {colType} DEFAULT {defaultValue} ";
					var cmd = new OleDbCommand(query, con);
					try
					{
						con.Open();
						cmd.ExecuteNonQuery();
						Console.WriteLine("Sql Executed Successfully");
						return true;
					}
					catch (OleDbException e)
					{
						Console.WriteLine("Error Details: " + e);
					}
					finally
					{
						Console.WriteLine("closing conn");
						con.Close();
					}
					return false;
				}
				
		  public   void AddColumnTest()
				{
					OleDbConnection con = new OleDbConnection(myConnectionString);
					string tableName="table1";
					string colName="country";
					string colType="text (30)";
					object defaultValue = "USA";
					AddColumn(con, tableName, colName, colType, defaultValue);
				}				
				

		   public  bool AddColumnOfString_ToDataTable(string tableName, string newColumnName, string defaultCellValue)
				{
					// Approach: Accessing database at minimum time.
					//    returns true if  column name could not be found and column could be added
					DataTable table = new DataTable();
					
					//string strSQL = "SELECT " + tableName; // not valid syntax
					string strSQL = "SELECT * from " + tableName;
					OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, myConnectionString);
					adapter.Fill(table);
					OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
					bool result = false;
					// remove this code, it has no effect on the underlying base table in MS Access databas
					//any change in the structure of datatable has no effect on the database
					/*
					if (false == table.HasColumn(newColumnName))
					{
						DataColumn newColumn = new DataColumn(newColumnName, typeof(System.String));
						newColumn.DefaultValue = defaultCellValue;
						table.Columns.Add(newColumn);
						result = true;
					}
					*/
					//  code to modify data in DataTable here
					//Without the OleDbCommandBuilder this line would fail
					adapter.Update(table);
					//just to review the generated code					
					Console.WriteLine(builder.GetUpdateCommand().CommandText);
					Console.WriteLine(builder.GetInsertCommand().CommandText);
					return result;
				}

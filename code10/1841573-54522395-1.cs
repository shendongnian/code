	public void Main()
			{
				string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
				DateTime startDate = DateTime.Now.AddMonths(-1).AddDays(1 - DateTime.Now.Day);
				DateTime endDate = startDate.AddMonths(1).AddDays(-1);
				//var now = DateTime.Now;
				//var firstDayCurrentMonth = new DateTime(now.Year, now.Month, 1);
				//var lastDayLastMonth = firstDayCurrentMonth.AddDays(-1);
				try
				{
					//Declare Variables
					// string ExcelFileName = Dts.Variables["User::ExcelFileName"].Value.ToString() +" "+ String.Format("{0:M-d-yyyy}", endDate);
					string ExcelFileName = Dts.Variables["User::NewExcelFileName"].Value.ToString();
					string FolderPath = Dts.Variables["User::FolderPath"].Value.ToString();
					string StoredProcedureName = Dts.Variables["User::StoredProcedureName"].Value.ToString();
					string SheetName = Dts.Variables["User::SheetName"].Value.ToString();
					string connStringDB = "MyConnString";
					string excelConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}{1};Mode=ReadWrite;Extended Properties='Excel 12.0 Xml;HDR=YES';", FolderPath, ExcelFileName);
					using (var conn = new SqlConnection(connStringDB))
					using (var command = new SqlCommand(StoredProcedureName, conn)
					{
						CommandType = CommandType.StoredProcedure
					})
					{
						conn.Open();
						string queryString = String.Format("EXEC {0}", StoredProcedureName);
						SqlDataAdapter adapter = new SqlDataAdapter(queryString, conn);
						DataSet ds = new DataSet();
						adapter.SelectCommand.CommandTimeout = 0;
						adapter.Fill(ds);
						//Get Header Columns
						string TableColumns = "";
						// Get the Column List from Data Table so can create Excel Sheet with Header
						foreach (DataTable table in ds.Tables)
						{
							foreach (DataColumn column in table.Columns)
							{
								TableColumns += column + "],[";
							}
						}
						conn.Close();
						// Replace most right comma from Columnlist
						//TableColumns = ("[" + TableColumns.Replace(",", " Text,").TrimEnd(','));
						TableColumns = ("[" + TableColumns.Replace(",", " text,").TrimEnd(','));
						TableColumns = TableColumns.Remove(TableColumns.Length - 2);
						//Use OLE DB Connection and Create Excel Sheet
						using (OleDbConnection connODB = new OleDbConnection(excelConn))
						{
							connODB.Open();
							OleDbCommand cmd = new OleDbCommand();
							cmd.Connection = connODB;
							cmd.CommandTimeout = 0; //Entered by Oleg
							cmd.CommandText = String.Format("Create table {0} ({1})", SheetName, TableColumns);
							cmd.ExecuteNonQuery();
							foreach (DataTable table in ds.Tables)
							{
								String sqlCommandInsert = "";
								String sqlCommandValue = "";
								foreach (DataColumn dataColumn in table.Columns)
								{
									sqlCommandValue += dataColumn + "],[";
								}
								sqlCommandValue = "[" + sqlCommandValue.TrimEnd(',');
								sqlCommandValue = sqlCommandValue.Remove(sqlCommandValue.Length - 2);
								sqlCommandInsert = String.Format("INSERT INTO {0} ({1}) VALUES (", SheetName, sqlCommandValue);
								int columnCount = table.Columns.Count;
								foreach (DataRow row in table.Rows)
								{
									string columnvalues = "";
									for (int i = 0; i < columnCount; i++)
									{
										int index = table.Rows.IndexOf(row);
										var a = table.Rows[index].ItemArray[i].ToString().Replace("'", "''");
										columnvalues += "'" + a + "',";
										//columnvalues += "'" + table.Rows[index].ItemArray[i] + "',";
									}
									columnvalues = columnvalues.TrimEnd(',');
									var command2 = sqlCommandInsert + columnvalues + ")";
									cmd.CommandTimeout = 0;
									cmd.CommandText = command2;
									cmd.ExecuteNonQuery();
								}
							}
							conn.Close();
						}
					}
					Dts.TaskResult = (int)ScriptResults.Success;
				}
				catch (Exception exception)
				{
					// Create Log File for Errors
					using (StreamWriter sw = System.IO.File.CreateText(Dts.Variables["User::FolderPath"].Value.ToString() + "\\" +
						Dts.Variables["User::ExcelFileName"].Value.ToString() + datetime + ".log"))
					{
						sw.WriteLine(exception.ToString());
						Dts.TaskResult = (int)ScriptResults.Failure;
					}
				}
			}
		#region ScriptResults declaration
		/// <summary>
		/// This enum provides a convenient shorthand within the scope of this class for setting the
		/// result of the script.
		/// 
		/// This code was generated automatically.
		/// </summary>
		enum ScriptResults
			{
				Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
				Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
			};
			#endregion
		}
	}

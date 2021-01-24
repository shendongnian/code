    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string huru = openFileDialog1.FileName;
                    this.textBox1.Text = huru;
                    string pathConn;
                    //OleDbConnection conn;
                    DataTable spreadSheetData;
                    string sheetName = "";
                    OleDbCommand onlineConnection;
                    OleDbDataAdapter myDataAdapter;
                    DataTable dt = new DataTable();
    
                    if (huru.Substring(huru.Length - 3) == "lsx")
                    {
    
                        pathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + huru
                            + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
                    }
                    else
                    {
                        pathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + huru
                            + ";Extended Properties=\"Excel 8.0;HDR=yes;\";";
                    }
    				
    				using(OleDbConnection conn = ew OleDbConnection(pathConn))
    				{
    					//conn = new OleDbConnection(pathConn);
    					conn.Open();
    					spreadSheetData = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    					foreach (DataRow dr in spreadSheetData.Rows)
    					{
    						sheetName = dr["TABLE_NAME"].ToString();
    						sheetName = sheetName.Replace("'", "");
    						if (sheetName.EndsWith("$"))
    						{
    							onlineConnection = new OleDbCommand("SELECT * FROM [" + sheetName + "]", conn);
    							myDataAdapter = new OleDbDataAdapter(onlineConnection);
    							dt = new DataTable();
    							dt.TableName = sheetName;
    							myDataAdapter.Fill(dt);
    							ds.Tables.Add(dt);
    						}
    					}
    				}
                }

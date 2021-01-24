                DataTable dt = null;
                SqlBulkCopy copy = null;
                ofd.FileName = "";
                ofd.ShowDialog();
                string line = null;
                int i = 0;
                string symbolName = dt.Rows[1][0].ToString();
                string strConnection =
                @"Data Source =.\SQLEXPRESS; AttachDbFilename = C:\USERS\JEF\DOCUMENTS\DATABASE1.MDF; Integrated Security = True; Connect Timeout = 30; User Instance = True";
                SqlConnection condb2 = new SqlConnection(strConnection);
                string createTablerow ="create table ["+symbolName+"] (code1 VARCHAR(100) COLLATE Arabic_CI_AI_KS_WS,date1 varchar(50),open1 varchar(50),high1 varchar(50),low1 varchar(50),close1 varchar(50),vol1 varchar(50))";
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand command1 = new SqlCommand(createTablerow, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();
                    command1.CommandText = strConnection;
                    using (copy = new SqlBulkCopy(connection))
                    {
                        copy.ColumnMappings.Add(0, "code1");
                        copy.ColumnMappings.Add(1, "date1");
                        copy.ColumnMappings.Add(2, "open1");
                        copy.ColumnMappings.Add(3, "high1");
                        copy.ColumnMappings.Add(4, "low1");
                        copy.ColumnMappings.Add(5, "close1");
                        copy.ColumnMappings.Add(6, "vol1");
                        copy.DestinationTableName = "[" + symbolName + "]";
                    }
                    foreach (string file in ofd.FileNames)
                    {
                        using (StreamReader sr = File.OpenText(file))
                        {
                            dt = new DataTable();
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] data = line.Split(',');
                                if (data.Length > 0)
                                {
                                    if (i == 0)
                                    {
                                        foreach (var item in data)
                                        {
                                            dt.Columns.Add(new DataColumn());
                                        }
                                        i++;
                                    }
                                    DataRow row = dt.NewRow();
                                    row.ItemArray = data;
                                    dt.Rows.Add(row);
                                }
                                copy.WriteToServer(dt);
                            }
                        }
                    }
                }

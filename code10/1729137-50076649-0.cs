                    string[] arrFileName;
                    if (files != null && files.Length > 0)
                    {
                        arrFileName = new string[files.Length];
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FileName", "");
                        int Result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                                               
                        for (int i = 0; i < files.Length; i++)
                        {
                            string FileName = string.Empty;
                            string filepath = files[i];
                            FileName = filepath.Split('\\').Last();
                            ///////////Logic For Import File
                            using (StreamReader sr = new StreamReader(filepath))
                            {
                                string line = sr.ReadLine();
                                string[] value = line.Split(',');
                                DataTable dt = new DataTable();
                                DataRow row;
                                foreach (string dc in value)
                                {
                                    dt.Columns.Add(new DataColumn(dc));
                                }
                                dt.Columns.Add(new DataColumn("FileName"));
                                dt.Columns.Add(new DataColumn("Date"));
                                while (!sr.EndOfStream)
                                {
                                    value = sr.ReadLine().Split(',');
                                    row = dt.NewRow();
                                    row.ItemArray = value;
                                    row[9] = FileName;
                                    row[10] = DateTime.Now;
                                    dt.Rows.Add(row);
                                }
                                SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
                                bc.DestinationTableName = "InvoiceData";
                                bc.BatchSize = dt.Rows.Count;
                                con.Open();
                                bc.BulkCopyTimeout = 2000;
                                bc.WriteToServer(dt);
                                bc.Close();
                                con.Close();
                            }
                            //////Logic For Delete File From Folder if you want
                            File.Delete(filepath);
                        }
                        files = new string[] { };
                        txtFilePath.Text = null;
                        MessageBox.Show("Files Imported Susccessfully!!");
                    }
                    else
                    {
                        MessageBox.Show("Please Browse The File!!");
                    }

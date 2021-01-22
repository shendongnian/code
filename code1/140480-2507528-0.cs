     DataSet myDataset = new DataSet();
                    string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + @";Extended Properties=""Excel 12.0 Xml;HDR=YES""";
                    OleDbConnection myData = new OleDbConnection(strConn);
                    try {
                                          myData.Open();
                    }
                    catch (OleDbException e) {
                        try {
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filename + ";" + "Extended Properties=Excel 8.0;HDR=YES;";
                            myData = new OleDbConnection(strConn);
                            myData.Open();
                        }
                        catch (Exception e2) {
                            strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + @";Extended Properties=""HTML Import;HDR=YES;IMEX=1"";";
                            myData = new OleDbConnection(strConn);
                            myData.Open();
                        }
                    }
    
                    int i = 0;
                    foreach (DataRow row in myData.GetSchema("tables").Rows)
                        try {
                            i++;
                            string name = row[2].ToString().Replace("''", "'").TrimEnd('_');
                            DataSet ds = new DataSet();
                            OleDbDataAdapter d = new OleDbDataAdapter("SELECT * from [" + name + "]", strConn);
                            d.Fill(ds);
                            DataTable dt = ds.Tables[0].Copy();
                            dt.Namespace = name;
                            myDataset.Tables.Add(dt);
                        }
                        catch (Exception e) {
                        }
                    return myDataset;

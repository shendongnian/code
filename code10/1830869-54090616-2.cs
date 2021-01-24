      var table = new DataTable();
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        {
                            table.Load(rdr);
                        };
                    }
                    //con.Close();
                    List<string> labelList = new List<string>();
                    List<string> valueList = new List<string>();
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string label = row["Year"].ToString();
                            string value = row["Percentage"].ToString();
                            labelList.Add(label);
                            valueList.Add(value);
                        }
                    }

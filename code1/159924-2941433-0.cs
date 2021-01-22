     ArrayList list = new ArrayList();
                Dictionary<string, object> jsonOutput = new Dictionary<string, object>();
    
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in row.Table.Columns)
                    {
                        if (row[col] == DBNull.Value)
                            jsonOutput.Add(col.ColumnName, "");
                        else
                            jsonOutput.Add(col.ColumnName, row[col]);
                    }
    
                    list.Add(jsonOutput);
                    jsonOutput = new Dictionary<string, object>();
                }
                
    
                System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                return jss.Serialize(list);

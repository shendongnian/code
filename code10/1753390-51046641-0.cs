    var obj = ObjectToData(new SFSvc.Account(),"dbo.Account");
            // checking whether the table selected from the dataset exists in the database or not
            string exists = null;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM sysobjects where name = '" + obj.TableName + "'", conn);
                    exists = cmd.ExecuteScalar().ToString();
                }
                catch (Exception exce)
                {
                    exists = null;
                }
                if (exists == null)
                {
                    if (exists == null)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("CREATE TABLE " + obj.TableName);
                        sb.Append(" (");
                        foreach (DataColumn col in obj.Columns)
                        {
                            sb.Append(col.ColumnName + " varchar(MAX),");
                        }
                        string sql = sb.ToString().TrimEnd(',');
                        sql = sql + ")";
                        
                        SqlCommand createtable = new SqlCommand("CREATE TABLE " + sql, conn);
                        createtable.ExecuteNonQuery();
                        exists = obj.TableName;
                    }
                }
                conn.Close();
            }
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
                cn.Open();
                using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                {
                    foreach(DataColumn c in obj.Columns)
                    {
                        copy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                    }
                    copy.DestinationTableName = obj.TableName;
                    copy.WriteToServer(obj);
                }
                cn.Close();
            }
     public static DataTable ObjectToData(object o, string theName)
        {
            DataTable dt = new DataTable(theName);
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(o, null);
                    dt.Columns.Add(f.Name, f.PropertyType);
                    dt.Rows[0][f.Name] = f.GetValue(o, null);
                }
                catch { }
            });
            return dt;
        }

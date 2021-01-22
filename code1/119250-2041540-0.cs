    String tableName= "mytable";
    
               string select = "select * from "+tableName ;
               DataTable  dt=dbcon.ExecuteDataTable(select );
               StringBuilder sb = new StringBuilder();
               string pk="";
    
               sb.AppendFormat ( "select Name from sys.columns where Object_ID = Object_ID('{0}') and is_identity=1",tableName );
               try
               {
                   pk = dbcon.ExecuteScalar(sb.ToString()).ToString();
               }
               catch
               { }
               sb.Remove(0, sb.Length);
                foreach (DataRow dr in dt.Rows  )
                {
                    sb.Append("Insert INTO " + tableName + " VALUES( ");
                    foreach (DataColumn  dc in dt.Columns )
                    {
                        if (dc.ColumnName != pk)
                        {
                            string val = dr[dc].ToString();
    
                            if (dr[dc] == DBNull.Value)
                            {
                                sb.AppendFormat("{0} , ", "null");
                            }
                            else
                            {
                                sb.AppendFormat("'{0}' , ", dr[dc].ToString());
                            }
                        }
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.AppendLine(")");
                }

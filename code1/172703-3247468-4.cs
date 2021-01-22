    public string GoogleOrgChartJson(DataTable dt)
            {
                if ((dt == null) || (dt.Columns.Count == 0)) return "";
                var sb = new StringBuilder();
                sb.Append("{cols: [");
                foreach (DataColumn dc in dt.Columns.Cast<DataColumn>().Where(dc => dc.Caption != "Format"))
                {
                    sb.Append("{id: '");
                    sb.Append(dc.Caption);
                    sb.Append("', label: '");
                    sb.Append(dc.Caption);
                    sb.Append("', type: '");
                    sb.Append(dc.DataType.Name.ToLower());
                    sb.Append("'}, ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("], rows: [");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{c: [");
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ToString() == "Format")
                        {
                            sb.Remove(sb.Length - 3, 3);
                            sb.Append(", f: '");
                        }
                        else
                            sb.Append("{v: '");
    
                        if ((dr[i] != DBNull.Value) && (string)dr[i] != "")
                            sb.Append(dr[i] + "'}, ");
                        else
                            sb.Append("'}, ");
    
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append("]}, ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("]};");
                return sb.ToString();
            }

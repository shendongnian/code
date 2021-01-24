    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i != 0) sb.Append(",");
                        string name = "@P" + i;
                        cmd.Parameters.AddWithValue(name, dt.Rows[i]["3"]); //"3" is barcode column
                        sb.Append(name);
                    }
                    sb.Append(")");

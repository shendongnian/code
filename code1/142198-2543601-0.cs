    public string GetJSONString2(DataTable table)
    {
        StringBuilder headStrBuilder = new StringBuilder(table.Columns.Count * 5); //pre-allocate some space, default is 16 bytes
        for (int i = 0; i < table.Columns.Count; i++)
        {
            headStrBuilder.AppendFormat("\"{0}\" : \"{0}{1}¾\",", table.Columns[i].Caption, i);
        }
        headStrBuilder.Remove(headStrBuilder.Length - 1, 1); // trim away last ,
        StringBuilder sb = new StringBuilder(table.Rows.Count * 5); //pre-allocate some space
        sb.Append("{\"");
        sb.Append(table.TableName);
        sb.Append("\" : [");
        for (int i = 0; i < table.Rows.Count; i++)
        {
            string tempStr = headStrBuilder.ToString();
            sb.Append("{");
            for (int j = 0; j < table.Columns.Count; j++)
            {
                table.Rows[i][j] = table.Rows[i][j].ToString().Replace("'", "");
                tempStr = tempStr.Replace(table.Columns[j] + j.ToString() + "¾", table.Rows[i][j].ToString());
            }
            sb.Append(tempStr + "},");
        }
        sb.Remove(sb.Length - 1, 1); // trim last ,
        sb.Append("]}");
        return sb.ToString();
    }

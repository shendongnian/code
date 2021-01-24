    public string GridtoCVS(GridView gvParm)
    {
        StringBuilder sbRetVal = new StringBuilder();
        for (int i = 0; i <= gvParm.Rows.Count - 1; i++)
        {
            StringBuilder sbLine = new StringBuilder();
            for (int j = 0; j <= gvParm.Columns.Count - 1; j++)
            {
                sbLine.Append(gvParm.Rows[i].Cells[j].Text.Trim() + ",");
            }
            string sLine = sbLine.ToString().Replace("&nbsp;", "").Replace("&#39;","'").Replace("&amp;","&");
            
            sbRetVal.AppendLine(sLine);
        }
        return sbRetVal.ToString();
    }

        public DataSet duplicateRemoval(DataSet dSet) 
    {
        bool flag;
        int ccount = dSet.Tables[0].Columns.Count;
        string[] colst = new string[ccount];
        int p = 0;
        DataSet dsTemp = new DataSet();
        DataTable Tables = new DataTable();
        dsTemp.Tables.Add(Tables);
        for (int i = 0; i < ccount; i++)
        {
            dsTemp.Tables[0].Columns.Add(dSet.Tables[0].Columns[i].ColumnName, System.Type.GetType("System.String"));
        }
     
        foreach (System.Data.DataRow row in dSet.Tables[0].Rows)
        {
            flag = false;
            p = 0;
            foreach (System.Data.DataColumn col in dSet.Tables[0].Columns)
            {
                colst[p++] = row[col].ToString();
                if (!string.IsNullOrEmpty(row[col].ToString()))
                {  //Display only if any of the data is present in column
                    flag = true;
                }
            }
            if (flag == true)
            {
                DataRow myRow = dsTemp.Tables[0].NewRow();
                //Response.Write("<tr style=\"background:#d2d2d2;\">");
                for (int kk = 0; kk < ccount; kk++)
                {
                    myRow[kk] = colst[kk];         
                   
                    // Response.Write("<td class=\"table-line\" bgcolor=\"#D2D2D2\">" + colst[kk] + "</td>");
                }
                dsTemp.Tables[0].Rows.Add(myRow);
            }
        } return dsTemp;
    }

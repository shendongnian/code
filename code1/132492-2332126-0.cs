        DataTable dt = new DataTable();    
        foreach (GridViewRow row in yourGridView)
        {
            DataRow dr;
            dr = dt.NewRow();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[i].Text;
            }
    
            dt.Rows.Add(dr);
        }
    
    SqlBulkCopy sbc = new SqlBulkCopy(targetConnStr);
    sbc.DestinationTableName = "yourDestinationTable";
    sbc.WriteToServer(dt);
    sbc.Close();

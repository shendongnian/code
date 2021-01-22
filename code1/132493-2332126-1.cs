        DataTable dt = new DataTable();    
        for (int j = 0; j < grdList.Rows.Count; j++)
        {
            DataRow dr;
            GridViewRow row = grdList.Rows[j];
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

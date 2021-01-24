    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    foreach (DataGridViewRow row in dgvAtt.Rows)
    {
         //do stuff here
         string Query = "SELECT Signature FROM TBL_Student WHERE Name = '";
         if (row.Cells.Count >= 4 && row.Cells[4].Value != null)
         {
             Query += row.Cells[4].Value.ToString();
         }
         Query += "'";
        //do stuff here
    }
    dgvSign.DataSource = dt;

     DataTable dTable = dataGridView.GetTable().Tables[0];
     foreach (DataRow dataRow in dataGridView.GetTable().Tables[0].Rows)
     {
        int n = dataGridView.Rows.Add();
        foreach (DataColumn dataColumn in dTable.Columns)
        {
           dataGridView.Rows[n].Cells[dataColumn.ColumnName].Value = dataRow[dataColumn.ColumnName].ToString();
        }
     }

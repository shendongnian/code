     List<DataGridViewRow> newRowcheck = new List<DataGridViewRow>();
     List<DataGridViewRow> newRowUncheck = new List<DataGridViewRow>();
    
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value) == false)
                    {
                        newRowUncheck.Add(row);
                    }
                    else
                    {
                        newRowcheck.Add(row);
                    }
    
    
                }
    
    
                dataGridView1.Rows.Clear();
    
    
                int RowIndex;
    
                for (RowIndex = 0; RowIndex < newRowUncheck.Count; RowIndex++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[RowIndex].Cells[0].Value = newRowUncheck[RowIndex].Cells[0].Value;
                    dataGridView1.Rows[RowIndex].Cells[1].Value = newRowUncheck[RowIndex].Cells[1].Value;
    
                }
    
    
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
    
                DataGridView tempDataGridView = new DataGridView();
                tempDataGridView.Columns.Add("Column1", "Column1 Name in Text");
                tempDataGridView.Columns.Add("nColumn2", "Column2 Name in Text");
    
                for (int i = 0; i < newRowcheck.Count; i++)
                {
                    tempDataGridView.Rows.Add();
                    tempDataGridView.Rows[i].Cells[0].Value = newRowcheck[i].Cells[0].Value;
                    tempDataGridView.Rows[i].Cells[1].Value = newRowcheck[i].Cells[1].Value;
                }
    
                tempDataGridView.Sort(tempDataGridView.Columns[0], ListSortDirection.Descending);      
    
                for (int i = 0; i < tempDataGridView.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i + RowIndex - 1].Cells[0].Value = tempDataGridView.Rows[i].Cells[0].Value;
                    dataGridView1.Rows[i + RowIndex - 1].Cells[1].Value = tempDataGridView.Rows[i].Cells[1].Value;
                }

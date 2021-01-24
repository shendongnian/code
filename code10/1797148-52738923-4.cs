    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int rowindex = dataGridView1.Rows[e.RowIndex].Index;
                int columnindex = dataGridView1.Columns[1].Index;
    
                foreach (DataGridViewRow row in dataGridView2.Rows)
                    row.Selected = false;
    
                var cellValue1 = dataGridView1.Rows[rowindex].Cells[1].Value;  // 1 <= index of Name column in dgItems
    
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    var cellValue2 = row.Cells[0].Value; // 0 <= index of Name column in dgItemList
    
                    if (cellValue1 == cellValue2)
                        row.Selected = true;
                    else
                        row.Selected = false;
                }
            }

    foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = false;
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item.Cells[4].Value.ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item.Cells[5].Value.ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item.Cells[6].Value.ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item.Cells[7].Value.ToString();
                    dataGridView2.Rows[n].Cells[8].Value = item.Cells[8].Value.ToString();
                    dataGridView2.Rows[n].Cells[9].Value = item.Cells[9].Value.ToString();
                    dataGridView2.Rows[n].Cells[10].Value = item.Cells[10].Value;
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        if (dataGridView2.Columns[i] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                            break;
                        }
                    foreach (DataGridViewRow row in this.dataGridView2.Rows)
                    {
                        row.Cells[0].Value = true;
                    }
                }
            }

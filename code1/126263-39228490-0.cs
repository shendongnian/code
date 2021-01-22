           foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["columnname"].Value != null)
                        {
                            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.MistyRose;
                        }
                     }

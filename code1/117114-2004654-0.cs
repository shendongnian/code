    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {   
                foreach (string dns in dnsList)
                {
                    string currentCheck = String.Empty;
                    if (dataGridView1.Columns[e.ColumnIndex].Name.Equals(dnsList[0]))
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        DataGridViewCell cell = row.Cells[e.ColumnIndex];
                        cell.Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        for (int idx = 1; idx < dnsList.Count; idx++)
                        {
                            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals(dnsList[idx]))
                            {
                                DataGridViewRow rowCurrent = DataGridView1.Rows[e.RowIndex];
                                DataGridViewCell cellCurrent = rowCurrent.Cells[e.ColumnIndex];
                                
                                DataGridViewRow rowCheck = dataGridView1.Rows[e.RowIndex];
                                DataGridViewCell cellCheck = rowCheck.Cells[dnsList[0]];
                                
                                if (!cellCurrent.Value.ToString().Equals(cellCheck.Value.ToString()))
                                    cellCurrent.Style.BackColor = Color.LightSalmon;
                                else
                                    cellCurrent.Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }

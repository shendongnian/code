     private void compGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0)
                {
                    if ((bool)compGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue)
                    {
                        ComputersList.Add(compGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    else
                    {
                        ComputersList.Remove(compGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                }
            }

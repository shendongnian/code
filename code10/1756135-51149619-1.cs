      private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        double unitPrice = 0;
                        int quantity = 0;
						int.TryParse(row.Cells[dataGridView1.Columns[2].Index].Value, out quantity))
						if(quantity > 0)
						{
						 MessageBox.Show(" Error ");
						 return;
						}
                        unitPrice = Convert.ToDouble(row.Cells[dataGridView1.Columns[3].Index].Value);
                        row.Cells[dataGridView1.Columns[4].Index].Value = quantity * unitPrice;
                    }
                }
                catch (Exception ex)
                {
                }
            }

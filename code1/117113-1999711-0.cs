       private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
                {
                    switch (e.ColumnIndex)
                    {
                        case 3:
                            Customer customer = (Customer)customerBindingSource[e.RowIndex];
                            e.CellStyle.BackColor = Color.FromArgb(customer.Salary); // set unique color for each value
                            break;
                    }            
                   
                }

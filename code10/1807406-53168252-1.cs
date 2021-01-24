     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.SelectedRows[0];
                if (row.Cells[0].Value!=null && row.Cells[1].Value != null && row.Cells[2].Value != null) {
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();
                }
            }

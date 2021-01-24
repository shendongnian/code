     private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[1].Style.BackColor = Convert.ToInt32(row.Cells[0].Value) == 23 ? Color.Green : Color.Red; // Your condition
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Style = this.dataGridView1.DefaultCellStyle;
                }
            }
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;
            style.Font = new Font("Courier New", 14.4f, FontStyle.Bold);
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                cell.Style = style;
            } 
        }

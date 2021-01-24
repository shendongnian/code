            string tmp = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.WrapMode =
         DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode =
         DataGridViewAutoSizeRowsMode.AllCells;
            
            tmp += textBox1.Text + Environment.NewLine;
            dataGridView1.Rows[0].Cells[0].Value = tmp;
        }

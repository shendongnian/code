    private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Click Data";
            Random rnd = new Random();
            int RND = rnd.Next(1, 1003);
            btn.Text = "Click Here" + dataGridView1.RowCount + " " + RND.ToString();
            btn.Name = "btn" + RND.ToString();
            btn.Tag = "tag ->" + dataGridView1.RowCount;
            int rowIndex = dataGridView1.Rows.Add(btn);
            
            dataGridView1.Rows[rowIndex].Cells[0].Value = btn.Text;
            dataGridView1.Rows[rowIndex].Cells[1].Value = "Product " + dataGridView1.RowCount;
        }

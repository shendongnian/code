     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            textBox1.Text += "ligne clické " + e.RowIndex+ Environment.NewLine;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                textBox1.AppendText( "bouton clické  "+btn.Tag+ Environment.NewLine) ;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] row;
            row = new string[] { "", "Product "+dataGridView1.RowCount };            
            dataGridView1.Columns[1].ReadOnly = true;
            btn.HeaderText = "Click Data";           
            Random rnd = new Random();
            int RND = rnd.Next(1, 1003);
            btn.Text = "Click Here"+dataGridView1.RowCount+" " + RND.ToString(); 
            btn.Name = "btn"+RND.ToString();
            btn.Tag = "tag ->" + dataGridView1.RowCount;
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Rows.Add(row);
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 1;
            foreach (string item in Form1.list)
            {
                var newRow = dataGridView1.Rows.Add();
                //if checkbox from Form1 not checked
                if (item == string.Empty)
                    dataGridView1.Rows[newRow].Cells[0].Value = false.ToString();
                else
                    dataGridView1.Rows[newRow].Cells[0].Value = item;
            }
        }

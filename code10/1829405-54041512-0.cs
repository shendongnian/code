    for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int val = Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                if (val < 5)
                {
                   dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

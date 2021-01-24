    for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var r1 = dataGridView1.Rows[i];
                var r2 = dataGridView2.Rows[i];
    
                if (r1.Cells[0].Value == r2.Cells[0] &&
                    r1.Cells[1].Value == r2.Cells[1])
                {
                    r1.Cells[2].Value = r2.Cells[2].Value;
                }
            }

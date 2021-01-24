            for (int i = dataGridView1.Rows.Count; i > -1; --i)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (!row.IsNewRow && row.Cells[0].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
                DataGridViewColumn clmn = dataGridView1.Columns[i];
                if (row.Cells[0].Value == null)
                {
                    dataGridView1.Columns.RemoveAt(i);
                }
            }

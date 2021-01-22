            //Copy column captions into DataGridView
            for (int i = 0; i < table.Columns.Count; i++) {
                if (dataGridView1.Columns.Count >= i) {
                    dataGridView1.Columns[i].HeaderText = table.Columns[i].Caption;
                }
            }

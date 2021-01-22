                var query = from DataGridViewColumn col in dataGridView1.Columns
                            orderby col.DisplayIndex
                            select col;
                foreach (DataGridViewColumn col in query)
                {
                    MessageBox.Show(col.HeaderText);
                    MessageBox.Show(col.DisplayIndex.ToString());
                 }

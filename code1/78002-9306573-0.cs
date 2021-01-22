            for (int i = 0; i < dgverlist.RowCount; i++)
            {
                for (int j = 2; j < dgverlist.ColumnCount; j++)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dgverlist.Rows[i].Cells[j];
                  
                    if (ch1.Value != null)
                    {
                       o[i] = ch1.OwningColumn.HeaderText.ToString();
                        
                        MessageBox.Show(o[i].ToString());
                    }
                }

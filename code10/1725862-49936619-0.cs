     string s = Clipboard.GetText();
            string[] lines = s.Split('\n');
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex;
            while (lines.Length != (dataGridView1.RowCount -row))
            {
                dt.Rows.Add();
            }
            foreach (string line in lines)
            {
                if (row < dataGridView1.RowCount && line.Length >0)
                {
                    
                    string[] cells = line.Split('\t');
                    while(cells.Length != (dataGridView1.ColumnCount - col))
                    {
                        dt.Columns.Add();
                    }
                    for (int i = 0; i < cells.GetLength(0); ++i)
                    {
                        if (col + i < this.dataGridView1.ColumnCount)
                        {
                            dataGridView1[col + i, row].Value = Convert.ChangeType(cells[i], dataGridView1[col + i, row].ValueType);
                        }
                        else
                        {
                            break;
                        }
                    }
                    row++;
                }
                else
                {
                    break;
                }
            }

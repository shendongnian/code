                foreach (word.Table table in document.Tables)
                {
                    for (int row = 1; row <= table.Rows.Count; row++)
                    {
                        for (int col = 1; col <= table.Columns.Count; col++)
                        {
                           var cell = table.Cell(row, col);
                           var range = cell.Range;
                           var text = range.Text;
                        }
                    }
                }

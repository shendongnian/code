            // Pull in all the cells of the worksheet
            Range cells = xlWorkBook.Worksheets[1].Cells;
            // set each cell's format to Text
            cells.NumberFormat = "@";
            // reset horizontal alignment to the right
            cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            
            // now add values to the worksheet
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value.ToString();
                }
            }

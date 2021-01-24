     private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if ((e.RowIndex > 0) && (e.ColumnIndex > 0) && ((e.RowIndex % 2) == 0))
                {
                    if (!dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.Equals(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                        e.PaintContent(e.CellBounds);
                        e.Handled = true;
                    }
                }
            }

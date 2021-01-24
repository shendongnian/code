        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex + 1 >= dataGridView1.RowCount)
				return;
			string currentValue = dataGridView1[0, e.RowIndex] == null ? string.Empty : dataGridView1[0, e.RowIndex].Value.ToString();
			string nextValue = dataGridView1[0, e.RowIndex + 1] == null ? string.Empty : dataGridView1[0, e.RowIndex + 1].Value.ToString();
			Rectangle newRect = new Rectangle(e.CellBounds.X,
			   e.CellBounds.Y, e.CellBounds.Width,
			   e.CellBounds.Height);
			using (
				Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
				backColorBrush = new SolidBrush(e.CellStyle.BackColor),
				foregroundBrush = new SolidBrush(e.CellStyle.ForeColor),
				boldBorderBrush = new SolidBrush(Color.Black)
				)
			{
				using (Pen normalGridLinePen = new Pen(gridBrush),
					 boldGridLinePen = new Pen(boldBorderBrush, 2))
				{
					// Erase the cell.
					e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
					if (!currentValue.Equals(nextValue))
					{
						//Draw grid line on the bottom
						e.Graphics.DrawLine(boldGridLinePen, e.CellBounds.Left,
							e.CellBounds.Bottom, e.CellBounds.Right,
							e.CellBounds.Bottom);
					}
					e.Graphics.DrawRectangle(normalGridLinePen, newRect);
					// Draw the text content of the cell, ignoring alignment.
					if (e.Value != null)
					{
						e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
							foregroundBrush, e.CellBounds.X + 2,
							e.CellBounds.Y + 2, StringFormat.GenericDefault);
					}
					e.Handled = true;
				}
			}
		}

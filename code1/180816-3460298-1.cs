      private void dgvCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
      {
          if (e.ColumnIndex != -1) && (e.RowIndex != -1)
          {
              DataGridViewCell dgvCell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
              Pen greenPen = new Pen(Color.Green, 2);
              Boolean hasTooltip = !dgvCell.ToolTipText.Equals("");
              Boolean hasCompleted = (dgvCell.Tag as CellInfo).complete; // CellInfo is a custom class
              if (hasTooltip) && (hasCompleted)
              {
                  e.Handled = true;
                  e.Paint(e.ClipBounds, e.PaintParts);
                  e.Graphics.DrawRectangle(Pens.Blue, e.CellBounds.Left + 5, e.CellBounds.Top + 2, e.CellBounds.Width - 12, e.CellBounds.Height - 6);
                  e.Graphics.DrawRectangle(greenPen, e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 3, e.CellBounds.Height - 3);
              }
              else if (hasTooltip)
              {
                  e.Handled = true;
                  e.Paint(e.ClipBounds, e.PaintParts);
                  e.Graphics.DrawRectangle(Pens.Blue, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 2, e.CellBounds.Height - 2);
              }
              else if (hasCompleted)
              {
                  e.Handled = true;
                  e.Paint(e.ClipBounds, e.PaintParts);
                  e.Graphics.DrawRectangle(greenPen, e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 3, e.CellBounds.Height - 3);
              }
          }
      }

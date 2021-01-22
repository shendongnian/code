        /// <summary>
        /// When DataGridView_CellMouseClick ocurs, it gives the position relative to the cell clicked, but for context menus you need the position relative to the DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView that produces the event</param>
        /// <param name="e">Event arguments produced</param>
        /// <returns>The Location of the click, relative to the DataGridView</returns>
        public static Point PositionRelativeToDataGridViewFromDataGridViewCellMouseEventArgs(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (dgv.RowHeadersVisible)
                x += dgv.RowHeadersWidth;
            if (dgv.ColumnHeadersVisible)
                y += dgv.ColumnHeadersHeight;
            for (int j = 0; j < e.ColumnIndex; j++)
                if (dgv.Columns[j].Visible)
                    x += dgv.Columns[j].Width;
            for (int i = 0; i < e.RowIndex; i++)
                if (dgv.Rows[i].Visible)
                    y += dgv.Rows[i].Height;
            return new Point(x, y);
        }

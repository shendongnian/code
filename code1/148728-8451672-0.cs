		/// <summary>
		/// Reset datagrid row height
		/// </summary>
		/// <param name="row"></param>
		public void ResetRowHeight(DataGrid grid, DataGridRow row)
		{
			// only for autosize rows
			if (!double.IsNaN(row.Height)) return;
 
			// store current rowheight
			double rowheight = grid.RowHeight;
 
			// fore recalculating row height
			grid.RowHeight = 0;
			row.UpdateLayout();
 
			// restore rowheight
			grid.RowHeight = rowheight;
			row.UpdateLayout();
		}

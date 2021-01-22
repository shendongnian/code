        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnColumnHeaderMouseClick(e);
            var column = Columns[e.ColumnIndex];
            if (column.SortMode == DataGridViewColumnSortMode.Automatic
                || column.SortMode == DataGridViewColumnSortMode.NotSortable)
                Sort(column);
        }

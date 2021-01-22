        private string _lastSortColumn;
        private ListSortDirection _lastSortDirection;
        public void Sort(DataGridViewColumn column)
        {
            // Flip sort direction, if the column chosen was the same as last time
            if (column.Name == _lastSortColumn)
                _lastSortDirection = 1 - _lastSortDirection;
            // Otherwise, reset the sort direction to its default, ascending
            else
            {
                _lastSortColumn = column.Name;
                _lastSortDirection = ListSortDirection.Ascending;
            }
            // Prep data for sorting
            var data = (IEnumerable<dynamic>)DataSource;
            var orderProperty = column.DataPropertyName;
            // Sort data
            if (_lastSortDirection == ListSortDirection.Ascending)
                DataSource = data.OrderBy(x => x.GetType().GetProperty(orderProperty).GetValue(x, null)).ToList();
            else
                DataSource = data.OrderByDescending(x => x.GetType().GetProperty(orderProperty).GetValue(x, null)).ToList();
            // Set direction of the glyph
            Columns[column.Index].HeaderCell.SortGlyphDirection
                = _lastSortDirection == ListSortDirection.Ascending
                ? SortOrder.Ascending : SortOrder.Descending;
        }

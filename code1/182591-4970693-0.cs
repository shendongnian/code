        private static ListSortDirection _oldSortOrder;
        private static DataGridViewColumn _oldSortCol;
        /// <summary>
        /// Saves information about sorting column, to be restored later by calling RestoreSorting
        /// on the same DataGridView
        /// </summary>
        /// <param name="grid"></param>
        public static void SaveSorting(DataGridView grid)
        {
            _oldSortOrder = grid.SortOrder == SortOrder.Ascending ?
                ListSortDirection.Ascending : ListSortDirection.Descending;
            _oldSortCol = grid.SortedColumn;
        }
        /// <summary>
        /// Restores column sorting to a datagrid. You MUST call this AFTER calling 
        /// SaveSorting on the same DataGridView
        /// </summary>
        /// <param name="grid"></param>
        public static void RestoreSorting(DataGridView grid)
        {
            if (_oldSortCol != null)
            {
                DataGridViewColumn newCol = grid.Columns[_oldSortCol.Name];
                grid.Sort(newCol, _oldSortOrder);
            }
        }

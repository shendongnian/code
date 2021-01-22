        private void UpdateDataSource()
        {
            SuspendLayout();
            //Save last position and sort order
            DataGridView g = DataGridView1;
            Int32 idxFirstDisplayedScrollingRow = g.FirstDisplayedScrollingRowIndex;
            SortOrder dgvLastSortDirection = g.SortOrder;
            Int32 lastSortColumnPos = g.SortedColumn?.Index ?? -1;
            Int32 dgvLastCellRow = g.CurrentCell?.RowIndex ?? -1;
            Int32 dgvLastCellColumn = g.CurrentCell?.ColumnIndex ?? -1;
            //Set new datasource
            g.DataSource = myNewDataTableSource;                                                                     
            //Restore sort order, scroll row, and active cell
            g.InvokeIfRequired( o =>
            {
                if(lastSortColumnPos > -1)
                {
                    DataGridViewColumn newColumn = o.Columns[lastSortColumnPos];
                    switch(dgvLastSortDirection)
                    {
                        case SortOrder.Ascending:
                            o.Sort(newColumn, ListSortDirection.Ascending);
                            break;
                        case SortOrder.Descending:
                            o.Sort(newColumn, ListSortDirection.Descending);
                            break;
                        case SortOrder.None:
                            //No sort
                            break;
                    }
                }
                if(idxFirstDisplayedScrollingRow >= 0)
                    o.FirstDisplayedScrollingRowIndex = idxFirstDisplayedScrollingRow;
                if(dgvLastCellRow>-1 && dgvLastCellColumn>-1)
                    o.CurrentCell = g[dgvLastCellColumn, dgvLastCellRow];
            } );
            ResumeLayout();
        }
        public static void InvokeIfRequired<T>(this T obj, InvokeIfRequiredDelegate<T> action) where T : ISynchronizeInvoke
        {
            if (obj.InvokeRequired)
            {
                obj.Invoke(action, new Object[] { obj });
            }
            else
            {
                action(obj);
            }
        } 

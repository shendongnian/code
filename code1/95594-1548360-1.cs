    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = GetListViewSorter(e.Column);
            listView.ListViewItemSorter = sorter;
            listView.Sort();
        }
        private ListViewItemComparer GetListViewSorter(int columnIndex)
        {
            ListViewItemComparer sorter = (ListViewItemComparer)listView.ListViewItemSorter;
            if (sorter == null)
            {
                sorter = new ListViewItemComparer();
            }
            sorter.ColumnIndex = columnIndex;
            string columnName = packagedEstimateListView.Columns[columnIndex].Name;
            switch (columnName)
            {
                case ApplicationModel.DisplayColumns.DateCreated:
                case ApplicationModel.DisplayColumns.DateUpdated:
                    sorter.ColumnType = ColumnDataType.DateTime;
                    break;
                case ApplicationModel.DisplayColumns.NetTotal:
                case ApplicationModel.DisplayColumns.GrossTotal:
                    sorter.ColumnType = ColumnDataType.Decimal;
                    break;
                default:
                    sorter.ColumnType = ColumnDataType.String;
                    break;
            }
            if (sorter.SortDirection == SortOrder.Ascending)
            {
                sorter.SortDirection = SortOrder.Descending;
            }
            else
            {
                sorter.SortDirection = SortOrder.Ascending;
            }
            return sorter;
        }

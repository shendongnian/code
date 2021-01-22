    private void lvSeries_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorter s = (Sorter)lvSeries.ListViewItemSorter;
            s.Column = e.Column;
            if (s.Order == System.Windows.Forms.SortOrder.Ascending)
            {
                s.Order = System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            lvSeries.Sort();
        }

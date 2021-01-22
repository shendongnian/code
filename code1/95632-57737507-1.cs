    public class ListViewColumnSorterExt : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;
    
        private ListView listView;
        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorterExt(ListView lv)
        {
            listView = lv;
            listView.ListViewItemSorter = this;
            listView.ColumnClick += new ColumnClickEventHandler(listView_ColumnClick);
    
            // Initialize the column to '0'
            ColumnToSort = 0;
    
            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;
    
            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }
    
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ReverseSortOrderAndSort(e.Column, (ListView)sender);
        }
    
        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
    
            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
    
            if (decimal.TryParse(listviewX.SubItems[ColumnToSort].Text, out decimal dx) && decimal.TryParse(listviewY.SubItems[ColumnToSort].Text, out decimal dy))
            {
                //compare the 2 items as doubles
                compareResult = decimal.Compare(dx, dy);
            }
            else if (DateTime.TryParse(listviewX.SubItems[ColumnToSort].Text, out DateTime dtx) && DateTime.TryParse(listviewY.SubItems[ColumnToSort].Text, out DateTime dty))
            {
                //compare the 2 items as doubles
                compareResult = DateTime.Compare(dtx, dty);
            }
            else
            {
                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }
            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }
    
        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        private int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
    
        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        private SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    
        private void ReverseSortOrderAndSort(int column, ListView lv)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (column == this.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (this.Order == SortOrder.Ascending)
                {
                    this.Order = SortOrder.Descending;
                }
                else
                {
                    this.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                this.SortColumn = column;
                this.Order = SortOrder.Ascending;
            }
    
            // Perform the sort with these new sort options.
            lv.Sort();
        }
    }

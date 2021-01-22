    class ListViewAutoSorter : System.Collections.IComparer
    {
        private int Column = 0;
        private System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        public ListViewAutoSorter(int Column, SortOrder Order)
        {
            this.Column = Column;
            this.Order = Order;
        }
        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);
            var l1 = (ListViewItem)x;
            var l2 = (ListViewItem)y;
            var value1 = 0.0;
            var value2 = 0.0;
            if (Double.TryParse(l1.SubItems[Column].Text, out value1) && 
                Double.TryParse(l2.SubItems[Column].Text, out value2))
            {
                if (Order == SortOrder.Ascending)
                {
                    return value1.CompareTo(value2);
                }
                else
                {
                    return value2.CompareTo(value1);
                }
            }
            else
            {
                var str1 = l1.SubItems[Column].Text;
                var str2 = l2.SubItems[Column].Text;
                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }

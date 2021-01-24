    class ListViewItemComparer : IComparer
    {
        private int col1 = -1;
        private int col2 = -1;
        public ListViewItemComparer()
        {
            col1 = 0;
        }
        public ListViewItemComparer(int Column)
        {
            col1 = Column;
        }
        public ListViewItemComparer(int Column1, int Column2)
        {
            col1 = Column1;
            col2 = Column2;
        }
        public int Compare(object x, object y)
        {
            int result = string.Compare(((ListViewItem)x).SubItems[col1].Text, ((ListViewItem)y).SubItems[col1].Text);
            if (!(col2 < 0))
                result |= string.Compare(((ListViewItem)x).SubItems[col2].Text, ((ListViewItem)y).SubItems[col2].Text);
            return result;
        }
    }

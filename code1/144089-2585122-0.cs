    public int Compare(ListViewItem x, ListViewItem y)
    {
        ListViewItem.ListViewSubItem itemOne = x.SubItems[subItemIndex];
        ListViewItem.ListViewSubItem itemTwo = y.SubItems[subItemIndex];
        // if they're both empty, return 0
        if (string.IsNullOrEmpty(itemOne.Text) && string.IsNullOrEmpty(itemTwo.Text))
            return 0;
        // if itemOne is empty, it comes second
        if (string.IsNullOrEmpty(itemOne.Text))
            return 1;
        // if itemTwo is empty, it comes second
        if (string.IsNullOrEmpty(itemTwo.Text)
            return -1;
        uint itemOneComparison = uint.Parse(itemOne.Text);
        uint itemTwoComparison = uint.Parse(itemTwo.Text);
        // Calculate correct return value based on object comparison.
        int comparison = itemOneComparison.CompareTo(itemTwoComparison);
        if (OrderOfSort == SortOrder.Descending)
            comparison = (-comparison);
        return comparison;
    }

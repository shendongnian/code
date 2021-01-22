    /// <summary>
    /// Move the given item to the given index in the given group
    /// </summary>
    /// <remarks>The item and group must belong to the same ListView</remarks>
    public void MoveToGroup(ListViewItem lvi, ListViewGroup group, int indexInGroup) {
        group.ListView.BeginUpdate();
        ListViewItem[] items = new ListViewItem[group.Items.Count + 1];
        group.Items.CopyTo(items, 0);
        Array.Copy(items, indexInGroup, items, indexInGroup + 1, group.Items.Count - indexInGroup);
        items[indexInGroup] = lvi;
        for (int i = 0; i < items.Length; i++)
            items[i].Group = null;
        for (int i = 0; i < items.Length; i++) 
            group.Items.Add(items[i]);
        group.ListView.EndUpdate();
    }

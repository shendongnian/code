    private int getSelectedSubItemIndex(ListView listView)
    {
        if (listView.SelectedItems.Count == 1)
        {
            int x = 0;
            ListViewItem item = listView.SelectedItems[0];
            Point pt = listView.PointToClient(Control.MousePosition);
            for (int idx = 0; idx < item.SubItems.Count; ++idx)
            {
                x += listView.Columns[idx].Width;
                if (pt.X < x)
                    return idx;
            }
        }
        return -1;
    }

    ListViewItem item = GetItemFromPoint(listView1, Cursor.Position);
    if (e.Index != item.Index)
    {
        e.NewValue = e.CurrentValue;
        return;
    }
    listView1.Items[e.Index].Selected = !listView1.Items[e.Index].Selected;

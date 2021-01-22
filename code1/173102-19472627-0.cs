    private void ListViewAny_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((sender as ListView).FocusedItem != null)
        {
            (sender as ListView).FocusedItem.Selected = true;
        }
    }

    private void txtSearchMenu_TextChanged(object sender, EventArgs e)
    {
        string searchVal = txtSearchMenu.Text.ToLower();
        foreach (ListViewItem item in lvMenuItems.Items)
        {
            foreach (ListViewItem.ListViewSubItem subSearch in item.SubItems)
            {
                // move condition here
                if (searchVal != "" && subSearch.Text.ToLower().Contains(searchVal) == true)
                {
                    subSearch.BackColor = Color.MediumAquamarine;
                }
                else
                {
                    subSearch.BackColor = Color.White;
                }
            }
            item.UseItemStyleForSubItems = false;
        }
    }

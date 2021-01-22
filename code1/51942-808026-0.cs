    protected void btnAdd_Click(object sender, EventArgs e)
    {
        for (Int32 i = lstAvailableColors.Items.Count; i >= 0; i--)
        {
            ListItem item = lstAvailableColors.Items[i];
            if (item.Selected)
            {
                lstSelectedColors.Items.Add(item);
                lstAvailableColors.Items.Remove(item);
            }
        }
    }

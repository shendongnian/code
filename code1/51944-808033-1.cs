     protected void btnAdd_Click(object sender, EventArgs e)
        {
            var selected = new List<ListItem>();
            foreach (ListItem item in lstAvailableColors.Items)
            {
                if (item.Selected)
                {
                    selected.Add(item);
                    lstSelectedColors.Items.Add(item);
                }
            }
            foreach (ListItem item in selected)
            {
                lstAvailableColors.Items.Remove(item);
            }
        }

    foreach (ListViewItem errors in HazmatPackageErrorListview.Items)
    {
        StringBuilder builder = new StringBuilder();
        bool first = true;
        foreach (ListViewItem.ListViewSubItem error in errors.SubItems)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append(", ");
                builder.Append(error.Text);
            }
        }
        MessageBox.Show(builder.ToString()); // List concatenated subitems
    }

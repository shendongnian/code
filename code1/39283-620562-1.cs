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
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }
                builder.Append(error.Text);
            }
        }
        MessageBox.Show(builder.ToString()); // List concatenated subitems
    }

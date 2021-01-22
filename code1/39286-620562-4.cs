    foreach (ListViewItem errors in HazmatPackageErrorListview.Items)
    {
        StringBuilder builder = new StringBuilder();
        bool first = true;
        string prefix = "";
        foreach (ListViewItem.ListViewSubItem error in errors.SubItems)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append(prefix);
                prefix = ", ";
                builder.Append(error.Text);
            }
        }
        MessageBox.Show(builder.ToString()); // List concatenated subitems
    }

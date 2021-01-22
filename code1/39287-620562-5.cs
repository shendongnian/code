    foreach (ListViewItem errors in HazmatPackageErrorListview.Items)
    {
        string[] bits = errors.SubItems.Skip(1)
                              .Select(item => item.Text)
                              .ToArray();
        string errorLine = string.Join(", ", bits);
        MessageBox.Show(errorLine);
    }

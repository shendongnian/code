    private void Directory_KeyUp(object sender, KeyEventArgs e)
    {
        ComboBox box = sender as ComboBox;
        if (box.IsDropDownOpen && (e.Key == Key.Delete))
        {
            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            PropertyInfo hl = box.GetType().GetProperty("HighlightedItem", flags);
            if (hl != null)
            {
                String hlString = hl.GetValue(sender, null) as String;
                // TODO: remove from DirectoryList
            }
        }
    }

Below is the final code, as inspired by Jean Azzopardi's answer. The HighlightedItem that was showing up in the debugger was a non-public property and I am forcing access with a sequence of GetType().GetProperty().GetValue()
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

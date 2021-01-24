    bool IsEditing = false;
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        if (IsEditing || string.IsNullOrEmpty(entry.Text))
            return;
        IsEditing = true;
        if (entry.Text.Length > 20)
        {
            entry.Text = e.OldTextValue;
        }
        IsEditing = false;
    }

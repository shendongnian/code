    private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var s = sender as TextBox;
        // Use SelectionStart property to find the caret position.
        // Insert the previewed text into the existing text in the textbox.
        var text = s.Text.Insert(s.SelectionStart, e.Text);
        double d;
        // If parsing is successful, set Handled to false
        e.Handled = !double.TryParse(text, out d);
    }

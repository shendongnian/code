    private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = sender as TextBox;
        // Use SelectionStart property to find the caret position.
        // Insert the previewed text into the existing text in the textbox.
        var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
        double val;
        // If parsing is successful, set Handled to false
        e.Handled = !double.TryParse(fullText, out val);
    }

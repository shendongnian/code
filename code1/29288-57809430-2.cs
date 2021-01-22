private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
{
    var TextBox = (sender as TextBox);
    // if not a numeric value, remove news characters
    if (Regex.IsMatch(TextBox.Text, "[^0-9]"))
    {
        foreach (TextChange Change in e.Changes)
        {
            TextBox.Text = TextBox.Text.Remove(Change.Offset, Change.AddedLength);
            TextBox.CaretIndex = Change.Offset;
        }
    }
}

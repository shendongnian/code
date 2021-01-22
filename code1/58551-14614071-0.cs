    private string _filterRegexPattern = "[^a-zA-Z0-9];
    private int _stringMaxLength = 24;
    private void _inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(_filterRegexPattern))
        {
            var text = _inputTextBox.Text;
            var newText = Regex.Replace(_inputTextBox.Text, _filterRegexPattern, "");
            
            if (newText.Length > _stringMaxLength)
            {
                newText = newText.Substring(0, _stringMaxLength);
            }
            if (text.Length != newText.Length)
            {
                var selectionStart = _inputTextBox.SelectionStart;
                _inputTextBox.Text = newText;
                _inputTextBox.SelectionStart = selectionStart;
            }
        }
    }

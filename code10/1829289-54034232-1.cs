    private void txtNumber_PasteCommand(object sender, ExecutedRoutedEventArgs e)
    {
     string _copiedText = Clipboard.GetText();
     _copiedText = _copiedText.Replace("\n", " ").Replace("\r", "").Replace("'", 
        
                  "").Replace("\"", "") + " ";
           if (!string.IsNullOrEmpty(txtNumber.SelectedText))
           {
              txtNumber.SelectedText = SplitText(_copiedText,10);
           }
           else
           {
              txtNumber.Text += SplitText(_copiedText,10);
              txtNumber.Select(txtNumber.Text.Length, 1);
              txtNumber.ScrollToEnd();
              txtNumber.Focus();
           }
        }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            string txt = txtBox.Text;
            int lineNumber = txt.Split('\n').Length + 1;
            txtBox.Text += '\n' + lineNumber.ToString();
            txtBox.CaretIndex = txtBox.Text.Length;
        }
    }

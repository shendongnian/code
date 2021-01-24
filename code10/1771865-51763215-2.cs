    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string text = (string)e.DataObject.GetData(typeof(String));
            bool hasComma = false;
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && c != '.' && (c != ',' || hasComma))
                    e.CancelCommand();
                hasComma = c == ',';
            }
        }
        else
        {
            e.CancelCommand();
        }
    }

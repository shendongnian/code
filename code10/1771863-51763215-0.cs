    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string text = (String)e.DataObject.GetData(typeof(String));
            foreach (char c in text)
                if (!char.IsDigit(c) && c != '.' && c != ',')
                    e.CancelCommand();
        }
        else
        {
            e.CancelCommand();
        }
    }

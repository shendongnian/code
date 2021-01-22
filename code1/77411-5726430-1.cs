    private void txt_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        int iValue = -1;
    
        if (Int32.TryParse(textBox.Text, out iValue) == false)
        {
             TextChange textChange = e.Changes.ElementAt<TextChange>(0);
             int iAddedLength = textChange.AddedLength;
             int iOffset = textChange.Offset;
    
             textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
        }
    }

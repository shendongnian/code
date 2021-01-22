    private void PopTxtBoxLeavePreview(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            TextBox senderBox = (TextBox)sender;
            //remove leading 0:s.
            senderBox.Text = senderBox.Text.TrimStart('0');
            //remove spaces as group separator
            senderBox.Text = senderBox.Text.Replace(" ", "");
            //remove commas as group separator
            senderBox.Text = senderBox.Text.Replace(",", "");
            //remove singlequotes as group separator
            senderBox.Text = senderBox.Text.Replace("'", "");            
        }
    }

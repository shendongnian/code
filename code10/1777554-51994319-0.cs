    private void TextBox_Click(object sender, EventArgs e)
    {
        TextBox txtBox = (TextBox)sender;
        txtBox.SelectionStart = 0;
        // First click will select the text
        if (txtBox.Tag == null)
        {
            txtBox.Tag = true;
            txtBox.SelectionLength = txtBox.Text.Length;
        }
        // Second click will deselect the text
        else
        {
            txtBox.Tag = null;
            txtBox.SelectionLength = 0;
        }
    }

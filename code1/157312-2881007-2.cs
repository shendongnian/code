    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // Do your thing with the supplied barcode! 
            e.Handled = true;
        }
    }

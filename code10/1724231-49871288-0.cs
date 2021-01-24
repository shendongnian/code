    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            if (this.ActiveControl == this.textBox1)
            {
                MessageBox.Show("Enter on TextBox1 handled.");
                return true; //Prevent further processing
            }
        }
        return base.ProcessDialogKey(keyData);
    }

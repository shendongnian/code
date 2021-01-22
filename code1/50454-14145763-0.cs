    private void acceptButton_Click(object sender, EventArgs e)
    {
        if (!isValid()) {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
    }

    private void rootBindingSource_CurrentItemChanged(object sender, System.EventArgs e)
    {
        toUserTextBox.Text = toUserTextBox.Text.ToUpper();
        readWriteAuthorization1.ResetControlAuthorization();
    }

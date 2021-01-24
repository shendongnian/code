    private TextBox CtrlTextbox;
    private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (RowIdx >= 0)
        {
            CtrlTextbox = (TextBox)e.Control;
            CtrlTextbox.KeyUp += CopyText;
        }
    }
    private void CopyText(object sender, KeyEventArgs e)
    {
        this.TextBox1.Text = sender.Text;
    }

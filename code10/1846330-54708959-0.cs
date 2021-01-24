    private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        // Textbox columns
        if (dgv.CurrentCell.ColumnIndex == 2)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += TextBox_KeyPress;
            }
        }
    }
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Only numeric characters allowed
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    public class dgv : DataGridView
    {
    protected override bool ProcessDialogKey(Keys keyData)
    {
        Keys key = (keyData & Keys.KeyCode);
        if (key == Keys.Enter)
        {
            return this.ProcessRightKey(keyData);
        }
        return base.ProcessDialogKey(keyData);
    }
    protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            return this.ProcessRightKey(e.KeyData);
        }
        return base.ProcessDataGridViewKey(e);
    }
}

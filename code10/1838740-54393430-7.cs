    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if ((keyData == (Keys.Control | Keys.V)) || (keyData == (Keys.Shift | Keys.Insert)))
        {
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            this.ContextMenu = new ContextMenu();
            return;
        }
        base.OnMouseDown(e);
    }

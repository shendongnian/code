    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
    {
        if ((keyData == (Keys.Control | Keys.V)) || (keyData == (Keys.Shift | Keys.Insert))) {
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    ContextMenu emptyMenu = new ContextMenu();
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right) {
            this.ContextMenu = emptyMenu;
            return;
        }
        base.OnMouseDown(e);
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing && this.emptyMenu != null) {
            this.emptyMenu.Dispose();
        }
        base.Dispose(disposing);
    }

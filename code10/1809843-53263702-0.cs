    Control CurrentContextMenuOwner = null;
    private void contextMenuStrip1_Opened(object sender, EventArgs e)
    {
        CurrentContextMenuOwner = (sender as ContextMenuStrip).SourceControl;
    }
    private void toolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurrentContextMenuOwner.BackColor = Color.Blue;
        //(...)
    }
    private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
    {
        CurrentContextMenuOwner = null;
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        // Make sure that all items have updated databindings.
        foreach (Control C in this.Controls)
        {
            C.SuspendLayout();
            foreach (Binding b in C.DataBindings)
            {
                // Help: this doesn't seem to be working.
                b.WriteValue();
            }
            C.ResumeLayout();
        }
    }

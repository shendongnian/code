    private void UpdateToolStripItemText(ToolStripItem toolStripItem, string text)
    {
        if (InvokeRequired)
        {
            Invoke(new UpdateToolStripItemTextDelegate(UpdateToolStripItemText), new object[] { toolStripItem, text });
        }
        else
        {
            if (text != null)
            {
                toolStripItem.Text = text;
            }
        }
    }

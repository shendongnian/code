    if (Clipboard.ContainsText(TextDataFormat.Text))
    {
    pegarToolStripMenuItem1.Enabled = true;
    }
    else
    {
    pegarToolStripMenuItem1.Enabled = false;
        
    if (Clipboard.ContainsImage())
    {
    pegarToolStripMenuItem1.Enabled = true;
    }
    else
    {
    pegarToolStripMenuItem1.Enabled = false;
    }
    }

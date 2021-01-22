    private void btnClipboard_Click(object sender, EventArgs e)
    {
        String clipText = string.Empty;
        foreach (ListViewItem item in lstSerials.Items)
        {
            clipText += item.SubItems[0].Text;
            clipText += Environment.NewLine;
        }
        if (!String.IsNullOrEmpty(clipText))
        {
            Clipboard.SetText(clipText);
        }
    }

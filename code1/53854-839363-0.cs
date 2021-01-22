    RichTextBoxFinds options = RichTextBoxFinds.None;
    
    int from = ControlToSearch.SelectionStart;
    int to = ControlToSearch.TextLength - 1;
    if (chkMatchCase.Checked)
    {
        options = options | RichTextBoxFinds.MatchCase;
    }
    if (chkSearchUp.Checked)
    {
        options = options | RichTextBoxFinds.Reverse;
        to = from;
        from = 0;
    }
    int start = 0;
    start = ControlToSearch.Find(txtSearchText.Text, from, to, options);
    if (start > 0)
    {
        ControlToSearch.SelectionStart = start;
        ControlToSearch.SelectionLength = txtSearchText.TextLength;
        ControlToSearch.ScrollToCaret();
        ControlToSearch.Refresh();
        ControlToSearch.Focus();
    }
    else
    {
        MessageBox.Show("No match found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

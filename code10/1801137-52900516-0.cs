    //while initializing
    chkCollection.Add(chkByName);
    chkCollection.Add(chkByDesing);
    ...
    private void chkAll_CheckedChanged(
        object sender, EventArgs e)
    {
        foreach (var chk in chkCollection)
            chk.Checked = checkAll.Checked;
    }

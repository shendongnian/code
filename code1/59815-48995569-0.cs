    private void dgvList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvList.CurrentCell is DataGridViewCheckBoxCell)
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // Now this will fire immediately when a check box cell is changed,
        // regardless of whether the user uses the mouse, keyboard, or touchscreen.
        //
        // Value property is up to date, you DO NOT need EditedFormattedValue here.
    }

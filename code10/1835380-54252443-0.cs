    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        DialogResult dr = MessageBox.Show("Do you want to save ?", "Message", 
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        if (dr == DialogResult.Yes)
        {
            this.tableTableAdapter.Update(closureDataDataSet.Table);
            // dgvClosures.Refresh();
        }
    }

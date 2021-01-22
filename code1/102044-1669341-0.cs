    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        // Confirm user wants to close
        if (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
        }        
    }

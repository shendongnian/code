    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        // Confirm user wants to close
        switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
        {
        case DialogResult.No:
            e.Cancel = true;
            break;
        default:
            break;
        }        
    }

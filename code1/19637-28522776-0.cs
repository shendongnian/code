    private void btnDoLongRunningOperation_Click(object sender, System.EventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;
        LongRunningOperation();
        this.Cursor = Cursors.Arrow;
    }

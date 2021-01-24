    protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
    {
        base.OnPrintPage(e);
        // Create a new instance of Margins with 1-inch margins.
        e.PageSettings.Margins = new System.Drawing.Printing.Margins(100, 100, 100,100);
    }

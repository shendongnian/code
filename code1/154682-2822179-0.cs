    ts.Items.Remove(printButton);
    ToolStripButton b = new ToolStripButton();
    b.ImageIndex = printButton.ImageIndex;
    b.Visible = true;
    ts.Items.Insert(0, b);
    b.Click += new EventHandler(this.SelectPrinterAfterPreview);

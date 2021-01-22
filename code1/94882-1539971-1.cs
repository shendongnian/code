    private ToolStripButton myTestButton;
    public MyPrintPreviewDialog() : base()
    {
        Type T = typeof(PrintPreviewDialog);
        FieldInfo fi = T.GetField("toolStrip1", BindingFlags.Instance | 
        BindingFlags.NonPublic);
        ToolStrip toolStrip1 = (ToolStrip)fi.GetValue(this);
        myTestButton = new ToolStripButton();
        myTestButton.ToolTipText = "TEST";
        myTestButton.ImageIndex = 0;
        myTestButton.Click += new EventHandler(Btn_Click);
        Button Btn = new Button();
        toolStrip1.Items.Add(myTestButton);
    }
    private void Btn_Click(object Sender, EventArgs args)
    {
        MessageBox.Show("Button Clicked");
    }

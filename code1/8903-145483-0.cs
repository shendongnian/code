    public Form1()
    {
        InitializeComponent();
        tooltip = new ToolTip();
        tooltip.ShowAlways = true;
    }
    private ToolTip tooltip;
    private void toolStripButton_MouseHover(object sender, EventArgs e)
    {
        if (!this.Focused)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            tooltip.SetToolTip(toolStrip1, tsi.AutoToolTip ? tsi.ToolTipText : tsi.Text);
            /*tooltip.Show(tsi.AutoToolTip ? tsi.ToolTipText : tsi.Text, this, 
                new Point(toolStrip1.Left, toolStrip1.Bottom));*/
        }
    }
    private void toolStripButton_MouseLeave(object sender, EventArgs e)
    {
        tooltip.RemoveAll();
    }

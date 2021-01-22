    public TheForm()
    {
    
        InitializeComponent();
        FixAmpersands(this.Controls);
    }
    private static void FixAmpersands(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is ToolStrip)
            {
                FixAmpersands((control as ToolStrip).Items);
            }
            if (control.Controls.Count > 0)
            {
                FixAmpersands(control.Controls);
            }
        }
    }
    
    private static void FixAmpersands(ToolStripItemCollection toolStripItems)
    {
        foreach (ToolStripItem item in toolStripItems)
        {
            if (item is ToolStripMenuItem)
            {
                ToolStripMenuItem tsmi = (ToolStripMenuItem)item;
                tsmi.Text = tsmi.Text.Replace("&", "&&");
                if (tsmi.DropDownItems.Count > 0)
                {
                    FixAmpersands(tsmi.DropDownItems);
                }
            }                
        }
    }

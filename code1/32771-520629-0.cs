    private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem subitemToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem subItem2ToolStripMenuItem;
    
    public void init()
    {
        // 
        // optionToolStripMenuItem
        // 
        this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.subitemToolStripMenuItem,
        this.subItem2ToolStripMenuItem});
        this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
        this.optionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.optionToolStripMenuItem.Text = "Option";
        // 
        // subitemToolStripMenuItem
        // 
        this.subitemToolStripMenuItem.Name = "subitemToolStripMenuItem";
        this.subitemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.subitemToolStripMenuItem.Text = "Subitem";
        // 
        // subItem2ToolStripMenuItem
        // 
        this.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem";
        this.subItem2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.subItem2ToolStripMenuItem.Text = "SubItem2";
        this.subItem2ToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subItem2ToolStripMenuItem_MouseDown);
        this.subItem2ToolStripMenuItem.Click += new System.EventHandler(this.subItem2ToolStripMenuItem_Click);
    }
    
    private bool wasRightClicked = false;
    private void subItem2ToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            wasRightClicked = true;
    }

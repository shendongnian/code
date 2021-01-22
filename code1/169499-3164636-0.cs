    using System;
    using System.Windows.Forms;
    
    public Form1()
    {
        this.pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
        
        this.ToolTip = new ToolTip();
        this.ToolTip.SetToolTip(this.pictureBox1, "The algorithm has been completed successfully.")
    }
    
    private ToolTip ToolTip
    {
        get;
        set;
    }
    
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        this.ToolTip.Active = false;
        this.ToolTip.Active = true;
    }

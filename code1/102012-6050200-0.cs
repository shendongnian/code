    private System.Windows.Forms.ToolTip toolTip1;
    private void YourControl_MouseHover(object sender, EventArgs e)
    {
         toolTip1 = new System.Windows.Forms.ToolTip();
         this.toolTip1.SetToolTip(this.YourControl, "Your text here :) ");
         this.toolTip1.ShowAlways = true;
    }

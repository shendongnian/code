    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
    
    private void textBox_MouseHover(object sender, EventArgs e)
    {
        ToolTip1.Show("YOUR TEXT", textBox);
    }
    
    private void textBox_MouseLeave(object sender, EventArgs e)
    {
        ToolTip1.Active = false;
        ToolTip1.Active = true;
    }

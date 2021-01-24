    private void apple1_Click(object sender, EventArgs e)
    {
        apple1.Image = Properties.Resources.apple;
        apple1.Tag = "apple";
    
        if ((string)apple1.Tag==(string)apple2.Tag)
        {
            apple1.Visible = false;
            apple2.Visible = false;
        }
    }
    private void apple2_Click(object sender, EventArgs e)
    {
        apple2.Image = Properties.Resources.apple;
        apple2.Tag = "apple";
    }

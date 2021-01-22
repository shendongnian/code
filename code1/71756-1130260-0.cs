    private void Form_Activated(object sender, System.EventArgs e)
    {
        if (this.Owner != null)
        {
            this.Owner.Enabled = false; 
        }
    }
    
    private void Form_Deactivate(object sender, System.EventArgs e)
    {
        if (this.Owner != null)
        {
            this.Owner.Enabled = true;
        }
    }

    private void UserControl1_FormActivate(object sender, EventArgs e)
    {
        label1.Text = "Acitve";
    }
    
    private void UserControl1_FormDeActivate(object sender, EventArgs e)
    {
        label1.Text = "InAcitve";
    }
    
    private void UserControl1_Load(object sender, EventArgs e)
    {
        this.ParentForm.Activated += UserControl1_FormActivate;
        this.ParentForm.Deactivate += UserControl1_FormDeActivate;
    }

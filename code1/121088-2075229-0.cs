    void addcontrol(Control ctl)
    {
        this.Controls.Add(ctl);            
    }
    private void btnNewControl_Click(object sender, EventArgs e)
    {
        addcontrol(new Button());
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        if(!DesignMode) //only time this.ParentForm should be null
            this.ParentForm.FormClosing += ParentForm_FormClosing;
    }
    
    private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Unregister events here
    }

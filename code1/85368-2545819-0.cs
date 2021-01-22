    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        this.ParentForm.FormClosing += ParentForm_FormClosing;
    }
    
    private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Unregister events here
    }

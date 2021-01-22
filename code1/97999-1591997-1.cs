    public event EventHandler OnUpload;
    protected void OnLoad(...){
       if (this.HasFile && this.OnUpload != null)
         this.OnUpload(this, EventArgs.Empty);
    }

    private ProgressBar progressBar;
    public Home()
    {
        this.InitializeComponent();
    }
    private void btnSend_Click( Object sender, EventArgs e )
    {
        Task.Run( (Action)this.LoadData )
    }
    private void UpdateProgress( Float progress )
    {
        if( this.InvokeRequired )
        {
            this.BeginInvoke( (Action<Float>)this.UpdateProgress, progress );
            return;
        }
        this.progressBar.Value = progress * this.progressBar.Maximum;
    }
    private void LoadData()
    {
        ETLBusiness etlBusiness = new ETLBusiness(filePath);
        etlBusiness.LoadData( this.UpdateProgress ); // You'll need to replace its progressBar parameter with a callback to `this.UpdateProgress`.
    }

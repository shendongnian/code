    public DealsForm()
    {
        InitializeComponent();
        //this.StartPosition = FormStartPosition.CenterParent;
    }
    //DealsForm_Load Event
    private void DealsForm_Load(object sender, EventArgs e)
    {
        this.Location = this.Owner.Location;  //NEW CODE
    }

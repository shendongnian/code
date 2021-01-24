    public SupplierForm
    {
        private IRefreshable parentform;
        public SupplierForm(IRefreshable parent)
        {
            InitializeComponent();
            parentform = parent;
        }
	//this is on `SupplierForm`
	private void backbutton1_Click(object sender, EventArgs e)
	{
		//closes module and .Focus() back to inventory form
		connection.Close();
		parentform.RefreshGrid();
		this.Close();
        }
    } 

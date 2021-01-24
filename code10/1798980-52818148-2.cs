    public SupplierForm : IRefreshable
    {
        private IRefreshable parentform;
        public SupplierForm(IRefreshable parent)
        {
            InitializeComponent();
            parentform = parent;
        }
        public void RefreshGrid()
        {
             // Your form-specific refresh code goes here
             this.SupplierGrid.Refresh();
        }
    }

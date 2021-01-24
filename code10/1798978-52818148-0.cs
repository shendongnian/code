    public SupplierForm : IRefreshable
    {
        private IRefreshable inventoryform;
        public SupplierForm(IRefreshable inventory)
        {
            InitializeComponent();
            inventoryform = inventory;
        }
    }

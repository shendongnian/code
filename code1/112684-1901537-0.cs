        public ShowCustomer()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }
        public void Refresh()
        {
            Message = "showing test customer at: " + DateTime.Now.ToString();
        }
 

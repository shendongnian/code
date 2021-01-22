        public class CustomCollection { public string Value { get; set; } }
        public Supplies()
        {
            InitializeComponent();
            List<CustomCollection> l = new List<CustomCollection> { new CustomCollection { Value = "hello" } };
            this.SuppliesDataGridView.DataSource = l;
        }

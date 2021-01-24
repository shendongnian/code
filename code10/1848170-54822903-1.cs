             public ObservableCollection<MyClass> DataSource { get; set; }
        public MainPage()
        {
            this.BindingContext = this;
            DataSource = new ObservableCollection<MyClass>();
            DataSource.Add(new MyClass() { Name = "Item 1", Description = "Sub Item Text 1" });
            DataSource.Add(new MyClass() { Name = "Item 2", Description = "Sub Item Text 2" });
            DataSource.Add(new MyClass() { Name = "Item 3", Description = "Sub Item Text 3" });
        
            InitializeComponent();
        }

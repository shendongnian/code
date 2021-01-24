        BackgroundWorker backgroundWorker;
        public MainWindow()
        {
            InitializeComponent();
            // initializing GridView with data 
            this.dataGrid.ItemsSource = new people[] {
                new people { Name = "John", LastName="Doe", Age = 40 } };
            // adding a button click handler
            this.btnAddPeople.Click += BtnAddPeople_Click;
            
            backgroundWorker = backgroundWorker ?? new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }
        private void BtnAddPeople_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var newList = this.dataGrid.ItemsSource.Cast<people>().Union(
                    new[] {
                        new people { Name = "Asher", LastName = "Richard", Age = 26 },
                        new people { Name = "Joyce", LastName = "Herrera", Age = 37 }
                    }
                );            
            this.dataGrid.ItemsSource = newList;
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            Thread.Sleep(1000);            
        }
        class people
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

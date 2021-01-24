        public MainWindow()
        {
            InitializeComponent();
            objMultiColumnViewModel = this.DataContext as MultiColumnViewModel;
        }
        private MultiColumnViewModel objMultiColumnViewModel;

        public MainWindow()
        {
            InitializeComponent();
            // ...
            
            // this will cause the "MySelected" binding to target the correct property on this object
            MyComboBox.DataContext = this;
        }

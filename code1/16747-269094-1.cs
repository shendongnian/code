    public ObservableCollection<testClass> tests = new ObservableCollection<testClass>();
    
            public Window1()
            {
                InitializeComponent();
                tests.Add(new testClass("Row 1"));
                tests.Add(new testClass("Row 2"));
                tests.Add(new testClass("Row 3"));
                tests.Add(new testClass("Row 4"));
                tests.Add(new testClass("Row 5"));
                tests.Add(new testClass("Row 6"));
                TheList.ItemsSource = tests;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                tests[3].Selected = true;
                TheList.SelectedItem = tests[3];
            }

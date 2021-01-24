    public ObservableCollection<KeyValuePair<string, int>> ChartValues1 = new ObservableCollection<KeyValuePair<string, int>> ();
        public ObservableCollection<KeyValuePair<string, int>> ChartValues2 = new ObservableCollection<KeyValuePair<string, int>> ();
        public MainWindow () {
            InitializeComponent ();
            (line1 as LineSeries).ItemsSource = ChartValues1;
            (line2 as LineSeries).ItemsSource = ChartValues2;
        }
        private void Button_Click (object sender, RoutedEventArgs e) {
            //for line1
            string inputX = this.t1.Text.ToString ();
            int inputY = Convert.ToInt32 (this.t2.Text.ToString ());
            ChartValues1.Add (new KeyValuePair<string, int> (inputX, inputY));
            ChartValues1.Add (new KeyValuePair<string, int> ("c1 L-1", 22));
            ChartValues1.Add (new KeyValuePair<string, int> ("c2 L-1", 5));
            ChartValues1.Add (new KeyValuePair<string, int> ("c3 L-1", 19));
            //for line2
            string inputX1 = this.t3.Text.ToString ();
            int inputY1 = Convert.ToInt32 (this.t2.Text.ToString ());
            ChartValues2.Add (new KeyValuePair<string, int> (inputX1, inputY1));
            ChartValues2.Add (new KeyValuePair<string, int> ("c4 L-2", 17));
            ChartValues2.Add (new KeyValuePair<string, int> ("c5 L-2", 2));
            ChartValues2.Add (new KeyValuePair<string, int> ("c6 L-2", 21));
        }

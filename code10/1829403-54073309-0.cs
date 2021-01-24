        public Settings()
        {
            InitializeComponent();
            Test2 = new ObservableCollection<ushort>();
            Test2.Add(100);
            Test2.Add(99);
            Test2.Add(98);
            
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
                Task.Run(async () =>
                {
                    int i = 0;
                    while (true)
                    {
                        await Task.Delay(500);
                        Dispatcher.Invoke(() =>
                        {
                            Test2[1] += (ushort)2;
                            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test2)));
                        });
                    }
                });
        }
    public void Button_Click(object sender, RoutedEventArgs e)
        {          
          dispatcherTimer.Start();
        }

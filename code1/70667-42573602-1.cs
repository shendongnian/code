        public partial class MainWindow: Window
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
            bool running = true;
    
            public MainWindow()
            {
                InitializeComponent();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += timer_Tick;
                timer.Start();
            }
                  
            private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
            {
                running = true;
                e.CanExecute = true;
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                if (!running)
                    App.Current.Shutdown();
    
                running = false;
            }
        }

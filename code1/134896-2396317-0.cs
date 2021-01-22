		public MainWindow()
		{
			this.InitializeComponent();
			
			//Initializes the mainwindow in a user loogedoff state
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
			ExtendedVisualStateManager.GoToElementState(this.LayoutRoot as FrameworkElement, "LoggedOff", false);        
		}

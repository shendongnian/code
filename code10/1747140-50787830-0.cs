    public MainWindow()
    {
        InitializeComponent();
        DataContext = new EvaluationViewModel();
        Loaded += MainWindow_Loaded;
      
    }
    
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() => Thread.Sleep(2000))
        .ContinueWith((t) =>
        {
            (DataContext as EvaluationViewModel).Evaluations.Add(
          new Evaluation() { ID = 2, BirthDate = DateTime.Now.AddYears(-22), TestDate = DateTime.Now });
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

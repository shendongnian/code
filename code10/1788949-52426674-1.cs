    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainViewModel();
        DataContext = vm;
        vm.TrainViewModel.Trains.Add(new Train
        {
            Name = "Train 1",
            Details = "Details of Train 1"
        });
        vm.TrainViewModel.Trains.Add(new Train
        {
            Name = "Train 2",
            Details = "Details of Train 2"
        });
    }

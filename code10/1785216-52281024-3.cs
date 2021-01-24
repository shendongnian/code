    private MainViewModel _viewModel;
    public MainWindow() {
        _viewModel = new MainViewModel();
        DataContext = _viewModel;
        // anywhere in code you can use your _viewModel to exchange data
    }
    public OpenOptionsWindowCode() {
        var options = new OptionsWindow();
        options.DataContext = _viewModel;
        options.Show();
    }

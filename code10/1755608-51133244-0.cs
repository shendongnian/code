    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var container = new StandardKernel();
        // Register types
        container.Bind<IEncrypterHelper>().To<EncrypterHelper>();
        container.Bind<Window>().To<MainWindow>();
        // Show the main window.
        MainWindow mw = new MainWindow();
        mw.DataContext = container.Get<MainWindowViewModel>();
        mw.Show();
    }

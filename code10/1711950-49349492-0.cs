    protected override void InitializeShell()
    {
        Container.RegisterType<IService, Service>();
        Application.Current.MainWindow.Show();
    }

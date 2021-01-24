    public FindWindow(FindModel model)
    {
        InitializeComponent();
        this.viewModel = Dependencies.Container.Instance.Resolve<FindWindowViewModel>(new ParameterOverride("access", this), new ParameterOverride("model", model));
        DataContext = viewModel;
        Loaded += (s, e) => FocusInput();
    }

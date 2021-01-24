    private IDependency _dep1;
    public Page()
    {
        _dep1 = ServiceLocator.Current.Resolve<IDependency>();
        init();
    }
    public Page(IDependency dep1, ...)
    {
        _dep1 = dep1;
        init();
    }
    private void init()
    {
        /* Do initialization here, i.e. InitializeComponent() */
    }

    private readonly SynchronizationContext syncContext;
    public Plot()
    {
        InitializeComponent();
        this.syncContext = System.Threading.SynchronizationContext.Current;
        ...
    }

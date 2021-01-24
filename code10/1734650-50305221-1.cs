    private bool _shown = false;
    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnContentRendered(EventArgs e)
    {
        base.OnContentRendered(e);
        if (_shown)
        {
            return;
        }
        _shown = true;
        ResizeTree();
    }

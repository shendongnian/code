    public MyControl()
    {
        InitializeComponent();
        txt.Validating += (obj, args) => OnValidating(args);
    }

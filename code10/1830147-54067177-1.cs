    public MainWindow()
    {
        InitializeComponent();
        seals = new CountySeals();
        this.DataContext = seals; // <---------
        ... etc ...

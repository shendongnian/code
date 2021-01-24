    public SketchDetailPage()
    {
        this.InitializeComponent();
        this.DataContext = new SketchDetailPageViewModel() { ImageUri= "ms-appx:///Assets/Image.png" };
    }
    
    internal SketchDetailPageViewModel ViewModel
    {
        get { return DataContext as SketchDetailPageViewModel; }
    }

    List<string> _easingType = new List<string>();  
    public MainPage()
    {
       this.InitializeComponent();
       _easingType.Add("test2");
       _easingType.Add("test1");
       this.DataContext = _easingType;
    }

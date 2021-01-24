    public Page6()
    {
        InitializeComponent();
        DataContext = this;
        BackColor = "Red";
    }
    
    private string _background;
    public string BackColor
    {
            get
            {
                return _background;
            }
    
            set
            {
                _background = value;
                OnPropertyChanged();
            }
    }

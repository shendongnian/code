    string _article;
    public string Article
    {
        get
        {
            return _article;
        }
        set
        {
            if (_article != value)
            {
                _article = value;
                OnPropertyChanged("Article");
            }
        }
    }
    bool atEnd;
    public bool AtEnd
    {
        get
        {
            return atEnd;
        }
        set
        {
            if (atEnd != value)
            {
                atEnd = value;
                OnPropertyChanged("AtEnd");
            }
        }
    }
    
    public MainPage()
    {
        Article = "<put in enough text here to force scrolling>";
        AtEnd = false;
        InitializeComponent();
        BindingContext = this;
    }
    void Handle_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
    {
        if (e.ScrollY + scrollView.Height >= scrollView.ContentSize.Height)
            AtEnd = true;
        else
            AtEnd = false;
    }

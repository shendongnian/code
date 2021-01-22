    public List<Template> MyTemplates {get; private set;}
    
    public TemplateList()
    {
        InitializeComponent();
        SetTemplates();
        DataContext = this;
    }
    
    // ItemsSource of ListBox
    public void SetTemplates()
    {
        // do stuff to set up the MyTemplates proeprty
        MyTemplates = something.ToList();
    }

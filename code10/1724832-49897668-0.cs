    public TasteView()
    {
        InitializeComponent();
        // DataContext der View auf ViewModel binden
        this.DataContext = new TasteViewModel(1,Brushes.Red,Brushes.Green,"Taste",Brushes.Blue);
    } 

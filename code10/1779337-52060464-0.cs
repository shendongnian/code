    private CurrentData currentData = CurrentData.GetInstance();
    private ObservableCollection<EntityType> Nodes { get; set; }
    private ObservableCollection<Association> Associations { get; set; }
    public MyDiagram()
    {
        InitializeComponent();
    }
    void OnLoad(object sender, RoutedEventArgs e)
    {
        Nodes = currentData.GetNodes();
        Associations = currentData.GetAssociations();
        Diagram.ItemsSource = Nodes;
        Diagram.ConnectionsSource = Associations;
        Diagram.ScaleToFit();
    }

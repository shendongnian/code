    ViewModel co;
    public TableView()
    {
        SQL.InsertNode();
        InitializeComponent();
        co = new ViewModel();
        base.DataContext = co;
    }
    public void AddNode()
    {
        SQL.InsertNode();
        co.Nodes.Clear();
        co.FillList();
    }

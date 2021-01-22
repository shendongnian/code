    public ObservableCollection<Button> Buttons { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        Buttons = new ObservableCollection<Button>();
        AddButton();
        DataContext = this;
    }
    private void ButtonAddButton_Click(object sender, RoutedEventArgs e)
    {
        AddButton();
    }
    private void AddButton()
    {
        var button = new Button();
        button.Content = "Add Button (" + Buttons.Count + ")";
        button.Click += ButtonAddButton_Click;
        Buttons.Add(button);
    }

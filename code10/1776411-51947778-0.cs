    public partial class MainWindow : Window
    {
        public ObservableCollection<Gun> GunsCollection { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            GunsCollection = new ObservableCollection<Gun>() 
            {
                new Gun() {ModelName = "AK-47", UnitCost = 2700 },
                new Gun() {ModelName = "M4A4", UnitCost = 3100 },
            };
        }
    }

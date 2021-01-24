    public partial class MainWindow : Window
    {
        public IEnumerable<MainCustomObject> MainCustomObjectList { get; set; } = new List<MainCustomObject>
        {
            new MainCustomObject
            {
                Id = 1,
                Name = "Name1",
                CustomObject1 = new CustomObject1
                {
                    Name = "Custom name 1",
                    Url = "Url 1"
                }
            }
        };
        public MainWindow()
        {
            InitializeComponent();
        }
    }

public partial class MainWindow : Window
    {
        private SomeCustomType registry;
        public SomeCustomType Registry { set { registry = value; } }
        public MainWindow()
        {
            InitializeComponent();
            this.comboBox.DataContext = this;
        }
    }
    public class SomeType
    {
        public static SomeCustomType Property1 { get { return new SomeCustomType() { Name = "Item1" }; } }
        public static SomeCustomType Property2 { get { return new SomeCustomType() { Name = "Item2" }; } }
    }
    public class SomeCustomType
    {
        public string Name { get; set; }
    }

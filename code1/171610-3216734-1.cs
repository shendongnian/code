    public partial class MainWindow : Window
    {
        public Node TheNode { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.TheNode = new Node();
            this.DataContext = this;
            this.Tab1.SetBinding(System.Windows.Controls.TabItem.HeaderProperty, "TheNode.Label");
            this.TheNode.Label = "Test";
        }
    }

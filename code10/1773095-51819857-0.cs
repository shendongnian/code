    public partial class MainWindow : Window
    {
        private readonly List<Ellipse> ellipsen = new List<Ellipse>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (Ellipse el in Halma.Children.OfType<Ellipse>())
            {
                ellipsen.Add(el);
            }
        }
    }

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
            img = new Image()
            {
                Source = ImageToBitmapImage(System.Drawing.Image.FromFile("C:\\some.img"))
            };
        }
        public Image img
        {
            get; set;
        }
    }

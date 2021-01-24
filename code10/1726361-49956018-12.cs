    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            BitmapImg = ImageToBitmapImage(System.Drawing.Image.FromFile(@"C:\some.img"));
            Img = new System.Windows.Controls.Image()
            {
                Source = BitmapImg
            };
            DataContext = this;
        }
        public System.Windows.Controls.Image Img
        {
            get; set;
        }
        public BitmapImage BitmapImg
        {
            get; set;
        }
    }

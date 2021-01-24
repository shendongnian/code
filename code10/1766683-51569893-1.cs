    public partial class Mini_Screen : Window
    {
        public Image DisplayImage
        {
            set
            {
                Imgbox2.Image = value;
            }
        }
    
        public Mini_Screen()
        {
            InitializeComponent();
        }
    }

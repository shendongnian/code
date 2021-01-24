    public partial class MainWindow : Window
    {
        public List<Picture> Pictures { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Pictures = new List<Picture>()
            {
                new Picture("https://images.askmen.com/1080x540/2017/01/06-044621-the_pitfalls_of_dating_a_married_woman.jpg", "Girl 1"),
                new Picture("https://images.pexels.com/photos/733872/pexels-photo-733872.jpeg?cs=srgb&dl=beautiful-blur-blurred-background-733872.jpg&fm=jpg", "Girl 2")
            };
    
            DataGrid.ItemsSource = Pictures;
        }
    }

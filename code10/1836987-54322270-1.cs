    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> tests { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            string path = "/Images/animals.jpg";
            tests = new ObservableCollection<Test>() { new Test() {ImgPath="ms-appx:///Assets/"+path } };
            FlipView.ItemsSource = tests;
        }
    }
    public class Test
    {
        public String ImgPath { get; set; }
    }

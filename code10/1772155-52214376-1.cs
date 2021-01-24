    public sealed partial class MainPage : Page
    {
        public ObservableCollection<VideoDetail> VideoDetails { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            VideoDetails = new ObservableCollection<VideoDetail>();
            for (int i=0;i<100;i++)
            {
                VideoDetails.Add(new VideoDetail() {Videoimage=new BitmapImage(new Uri("ms-appx:///Assets/panda.jpg")),Header=new BitmapImage(new Uri("ms-appx:///Assets/monkey.jpg")),Name="author",title="this is a video from test website",Time=DateTime.Now.Day.ToString(),Views=9000 });
            }
        }
    }
    public class VideoDetail
    {
        public BitmapImage Videoimage { get; set;}
        public BitmapImage Header { get; set; }
        public string title { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public string Time { get; set; }
    }

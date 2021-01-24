    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        bool replaceButtonClicked, replaceCustomButtonClicked, replaceTileButtonClicked;
    
        private void replace_Click(object sender, RoutedEventArgs e)
        {
            replaceButtonClicked = true;
            disappearStoryboard.Begin();
        }
    
        private void replaceCustom_Click(object sender, RoutedEventArgs e)
        {
            replaceCustomButtonClicked = true;
            disappearStoryboard.Begin();
        }
    
        private void replaceTile_Click(object sender, RoutedEventArgs e)
        {
            replaceTileButtonClicked = true;
            disappearStoryboard.Begin();
        }
    
        private void disappearStoryboard_Completed(object sender, object e)
        {
            if (replaceButtonClicked)
            {
                image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM200.png",
             UriKind.RelativeOrAbsolute));
                image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM201.png",
                  UriKind.RelativeOrAbsolute));
                image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM202.png",
                  UriKind.RelativeOrAbsolute));
                image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM203.png",
                  UriKind.RelativeOrAbsolute));
                image5.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM210.png",
                  UriKind.RelativeOrAbsolute));
                image6.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM211.png",
                  UriKind.RelativeOrAbsolute));
                image7.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM212.png",
                  UriKind.RelativeOrAbsolute));
                image8.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM213.png",
                  UriKind.RelativeOrAbsolute));
                image9.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM220.png",
                  UriKind.RelativeOrAbsolute));
                image10.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM221.png",
                  UriKind.RelativeOrAbsolute));
                image11.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM222.png",
                  UriKind.RelativeOrAbsolute));
                image12.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM223.png",
                  UriKind.RelativeOrAbsolute));
                replaceButtonClicked = false;
            }
            if (replaceCustomButtonClicked)
            {
                image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom200.png",
             UriKind.RelativeOrAbsolute));
                image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom201.png",
                  UriKind.RelativeOrAbsolute));
                image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom202.png",
                  UriKind.RelativeOrAbsolute));
                image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom203.png",
                  UriKind.RelativeOrAbsolute));
                image5.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom210.png",
                  UriKind.RelativeOrAbsolute));
                image6.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom211.png",
                  UriKind.RelativeOrAbsolute));
                image7.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom212.png",
                  UriKind.RelativeOrAbsolute));
                image8.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom213.png",
                  UriKind.RelativeOrAbsolute));
                image9.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom220.png",
                  UriKind.RelativeOrAbsolute));
                image10.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom221.png",
                  UriKind.RelativeOrAbsolute));
                image11.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom222.png",
                  UriKind.RelativeOrAbsolute));
                image12.Source = new BitmapImage(new Uri("ms-appx:///Assets/custom223.png",
                  UriKind.RelativeOrAbsolute));
                replaceCustomButtonClicked = false;
            }
            if (replaceTileButtonClicked)
            {
                image1.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM300.png",
             UriKind.RelativeOrAbsolute));
                image2.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM301.png",
                  UriKind.RelativeOrAbsolute));
                image3.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM302.png",
                  UriKind.RelativeOrAbsolute));
                image4.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM303.png",
                  UriKind.RelativeOrAbsolute));
                image5.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM304.png",
                  UriKind.RelativeOrAbsolute));
                image6.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM305.png",
                  UriKind.RelativeOrAbsolute));
                image7.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM306.png",
                  UriKind.RelativeOrAbsolute));
                image8.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM301.png",
                  UriKind.RelativeOrAbsolute));
                image9.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM302.png",
                  UriKind.RelativeOrAbsolute));
                image10.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM303.png",
                  UriKind.RelativeOrAbsolute));
                image11.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM310.png",
                  UriKind.RelativeOrAbsolute));
                image12.Source = new BitmapImage(new Uri("ms-appx:///Assets/OSM311.png",
                  UriKind.RelativeOrAbsolute));
                replaceTileButtonClicked = false;
            }
            displayStoryboard.Begin();
        }
    
    }

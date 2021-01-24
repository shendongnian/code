    public partial class SearchThumbnail : UserControl
    {
        public SearchThumbnail()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            nameof(Image), typeof(ImageSource), typeof(SearchThumbnail));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(SearchThumbnail));
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }

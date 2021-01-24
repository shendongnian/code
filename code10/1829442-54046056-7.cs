    /// <summary>
    /// Interaction logic for SomeContent.xaml
    /// </summary>
    public partial class SomeContent : UserControl
    {
        public static readonly DependencyProperty someProperty =
            DependencyProperty.Register(nameof(some), typeof(string),
                typeof(SomeContent),
                new PropertyMetadata("")
            );
        public string some
        {
            get => (string)GetValue(someProperty);
            set => SetValue(someProperty, value);
        }
        public SomeContent()
        {
            InitializeComponent();
        }
    }

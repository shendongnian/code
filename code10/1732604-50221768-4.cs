    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyProperty.Add(new RectOverlay() { wWidth = 100 });
        }
        public ObservableCollection<RectOverlay> MyProperty
        {
            get { return (ObservableCollection<RectOverlay>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(MyProperty), typeof(ObservableCollection<RectOverlay>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<RectOverlay>()));
    }

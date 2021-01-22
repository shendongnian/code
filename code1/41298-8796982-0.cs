    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            if (tb != null)
                tb.SelectAll();
            base.OnGotFocus(e);
        }
    }

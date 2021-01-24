    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate(typeof(HomeView));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.OriginalSource;
            Navigate(btn.Tag as Type);
        }
        private void Navigate (Type viewType)
        {
            UserControl uc;
            if (Views.ContainsKey(viewType))
            {
                uc = Views[viewType];
            }
            else
            {
                uc = (UserControl)Activator.CreateInstance(viewType);
                Views[viewType] = uc;
            }
            NavigationParent.Content = uc;
        }
        private Dictionary<Type, UserControl> Views = new Dictionary<Type, UserControl>();
    }

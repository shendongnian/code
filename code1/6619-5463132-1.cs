    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
        }
        void Home_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new FooDomainContext();
            var query = context.Load(context.GetPersonsQuery());
            TestList.ItemsSource = query.Entities;
            TestList.DisplayMemberPath = "name";
        }
    }

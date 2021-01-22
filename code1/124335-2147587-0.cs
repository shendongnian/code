    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var allRoles = new ObservableCollection<Role>()
            allRoles.Add(new Role("John", "Manager"));
            allRoles.Add(new Role("Anne", "Trainee"));
            this.DataContext = allRoles;
        }
    }

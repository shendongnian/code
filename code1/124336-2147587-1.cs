    public partial class MainWindow : Window
    {
        public ObservableCollection<Role> AllRoles {get;private set;}
        public MainWindow()
        {
            this.InitializeComponent();
            var allRoles = new ObservableCollection<Role>()
            allRoles.Add(new Role("John", "Manager"));
            allRoles.Add(new Role("Anne", "Trainee"));
            this.AllRoles = allRoles;
        }
    }

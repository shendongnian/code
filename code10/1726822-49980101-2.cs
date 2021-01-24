    public partial class MainPage : ContentPage {
        private readonly HttpClient _client = new HttpClient();
    
        public MainPage() {
            InitializeComponent();
            DataLoading += OnRolesLoading;
            RolesLoading(this, EventArgs.Empty);
        }
        private event EventHandler RolesLoading = delegate { };
    
        private async void OnRolesLoading(object sender, EventArgs args) {
            //DataLoading -= OnRolesLoading; //Optional
            try {
                await GetRoles();
            } catch {
                //...handler error
            }
        }
    
        private async Task GetRoles() {
            var result = await _client.GetStringAsync("{endpoint here}");
            var role = JsonConvert.DeserializeObject<List<Roles>>(result);
            RoleListView.ItemsSource = role;
        }
    }
 

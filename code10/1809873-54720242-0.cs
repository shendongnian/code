    public partial class MainPage : ContentPage {
    
        public MainPage() {
            InitializeComponent();
            Title = "MainPage";    
        }
    
        public void Bind() {
            BindingContext = new MainPageViewModel();
        }
    }

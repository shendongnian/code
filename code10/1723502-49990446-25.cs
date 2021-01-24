    internal sealed partial class SomePage {
        
        public SomePage() {
            InitializeComponent();
            ViewModel = App.Container.Resolve<SomePageViewModel>();
            this.DataContext = ViewModel;
        }
        
        public SomePageViewModel ViewModel { get; private set; }
        
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel.LoadAsync();
            base.OnNavigatedTo(e);
        }
    }
    

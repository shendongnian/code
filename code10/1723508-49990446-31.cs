    internal sealed partial class SomePage {
        public SomePage() {
            InitializeComponent();
        }
        public SomePageViewModel ViewModel { get { return (SomePageViewModel)DataContext;} }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel.LoadAsync();
            base.OnNavigatedTo(e);
        }
    }
    

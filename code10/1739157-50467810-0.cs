    public sealed partial class EditRules : INotifyPropertyChanged
    { 
        public EditRulesViewModel EditRulesViewModel {get; private set;}
    
        public EditRules()
        {
            DataContext = this;
            InitializeComponent();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EditRulesViewModel = (EditRulesViewModel)e.Parameter;
            OnPropertyChanged(nameof(this.EditRulesViewModel));
        }
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public sealed partial class SettingsPage : Page, INotifyPropertyChanged
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GlobalVariables.PropertyChanged += GlobalVariables_PropertyChanged;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            GlobalVariables.PropertyChanged -= GlobalVariables_PropertyChanged;
        }
        private void GlobalVariables_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GlobalVariables.FilePath):
                    NotifyPropertyChanged(nameof(TextBoxFilePath));
                    break;
                case nameof(GlobalVariables.FileName):
                    NotifyPropertyChanged(nameof(TextBoxFileName));
                    break;
            }
        }
        public string TextBoxFilePath => GlobalVariables.FilePath;
        public string TextBoxFileName => GlobalVariables.FileName;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }

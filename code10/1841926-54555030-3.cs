     public class MainViewModel : BindableObject
    {
        public Command AddButton { get; set; }
        private ObservableCollection<DefaultModel> defaultModels;
        public ObservableCollection<DefaultModel> DefaultModels
        {
            get { return defaultModels; }
            set
            {
                defaultModels = value;
                OnPropertyChanged(nameof(DefaultModels));
            }
        }
        public MainViewModel()
        {
            DefaultModels = new ObservableCollection<DefaultModel>();
            DefaultModels.Add(new DefaultModel());
            AddButton = new Command(AddButtonCommand);
        }
        private void AddButtonCommand(object obj)
        {
            DefaultModels.Add(new DefaultModel());
        }
    }

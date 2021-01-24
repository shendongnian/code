    class Model
    {
        public string Header { get; set; }
    }
    class MainViewModel : BindableBase
    {
        public ObservableCollection<Model> UserControls { get; set; }
        public ICommand AddButtonCommand { get; set; }
        public Window13ViewModel()
        {
            AddButtonCommand = new DelegateCommand(ClickButton);
            UserControls = new ObservableCollection<Model>();
        }
        private void ClickButton()
        {
            UserControls.Add(new Model() { Header = "some name..." });
        }
    }

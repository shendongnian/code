    public class PersonModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public PersonModel(string name)
        {
            _name = name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class PersonViewModel
    {
       public ObservableCollection<PersonModel> Items { get; set; }
       public PersonViewModel()
       {
           Items = new ObservableCollection<PersonModel> { new PersonModel("abc"), new PersonModel("def") };
       }
       public void Change()
       {
           Items[1].Name = "changed";
       }
    }
    public class ViewModelBase
    {
        public PersonViewModel PersonViewModel { get; set; }
        public ViewModelBase()
        {
            PersonViewModel = new PersonViewModel();
            PersonViewModel.Change();
        }
    }
    //Use the dataContext in this way, will help you with the strong type
    xmlns:viewModels="clr-namespace:WpfApp1.ViewModels"
    <Window.DataContext>
        <viewModels:ViewModelBase />
    </Window.DataContext>
    <Grid>
        <TextBox Text="{Binding PersonViewModel.Items[1].Name}" />
    </Grid>

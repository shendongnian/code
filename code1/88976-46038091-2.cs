     public class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            Persons = new ObservableCollection<PersonModel>
            {
                new PersonModel
                {
                    Name = "Jack",
                    Age = 30
                },
                new PersonModel
                {
                    Name = "Jon",
                    Age = 23
                },
                new PersonModel
                {
                    Name = "Max",
                    Age = 23
                },
            };
        }
        public ObservableCollection<PersonModel> Persons { get;}
        public PersonModel SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }
        //INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private PersonModel _selectedPerson;
    }

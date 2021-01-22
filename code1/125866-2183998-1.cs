    public class PersonViewModel : ViewModelBase
    {
        
        public PersonViewModel(Person person)
        {
            this.person = person;
        }
        public string Name
        {
            get
            {
                return this.person.Name;
            }
            set
            {
                this.person.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }

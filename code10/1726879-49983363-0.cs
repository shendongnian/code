    public class PersonViewModel
    {
        private readonly Person _person;
        public PersonViewModel(Person person)
        {
            _person = person;
        }
        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; RaisePropertyChanged(); }
        }
    }

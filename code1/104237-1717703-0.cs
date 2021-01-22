    class PersonModel : IPerson
    {
        // data access stuff goes in here
        public string Name { get; set; }
    }
    class PersonViewModel
    {
        IPerson _person;
        public PersonViewModel(IPerson person)
        {
            _person = person;
        }
        public Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }
     }

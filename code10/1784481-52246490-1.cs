    struct PersonEntry
    {
        private readonly Person _person;
        private readonly int _index;
        public PersonEntry(Person person, int index)
        {
            _person = person;
            _index = index;
        }
        public int Id
        {
            get => _person.id[ _index];
            set => _person.id[ _index] = value;
        }
        public int Name
        {
            get => _person.Name[ _index];
            set => _person.Name[ _index] = value;
        }
    }
    PersonEntry this[int index]
    {
        get => new PersonEntry(this, index);
    }

    public class PersonData {
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
    
    public class ExtendedPersonData: PersonData {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
    }

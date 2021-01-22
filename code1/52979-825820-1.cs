    public class CurrentPerson
    {
        public static Person Person { get; set; }
        public Guid Id
        {
            get { return CurrentPerson.Person.Id; }
            set { CurrentPerson.Person.Id = value; }
        }
        public String FirstName
        {
            get { return CurrentPerson.Person.FirstName; }
            set { CurrentPerson.Person.FirstName = value; }
        }
        public String LastName
        {
            get { return CurrentPerson.Person.LastName; }
            set { CurrentPerson.Person.LastName = value; }
        }
    }

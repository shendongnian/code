     public interface IPersonRepository
     {
        IEnumerable<Person> GetAllPersons();
        void AddPerson(Person person);
        // more...
     }

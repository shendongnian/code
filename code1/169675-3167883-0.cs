    public class Person
    {
        private DataManager.Person person;
    
        public Person(Datamanager.Person person)
        {
            this.person = person
        }
    
        public int ID
        {
            get { return person.ID; }
        }
    
        ...
    }

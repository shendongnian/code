    public class PersonRepository {
        public Person FindById(int id) {
            // Notice we are creating PersonProxy and not Person
            Person person = new PersonProxy();
            // Set person properties based on data from the database
            return person;
        }
        
        public IList<Child> GetChildrenForPerson(int personId) {
            // Return your list of children from the database
        }
    }

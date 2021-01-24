    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public static string GetInitials(Person person) {
            return person.FirstName[0].ToString() + person.LastName[0].ToString();
        }
    }

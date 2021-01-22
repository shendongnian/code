        public class Parties {
            Person Person {get; set;}
            Organization Organisation {get; set;}
            public Parties(Person person, Organization organisation) {
                Person = person;
                Organisation = organisation;
            }
        }
        public interface Person {}
        public interface Organization {}
        public class Business : Organization {}
        public class Contact: Person {
            public string FirstName{get; set;}
            public string LastName {get; set;}
            List<Role>roles = new List<Role>();
                public Contact() {}
                public Contact(Clients client)
                    : this() {
                    roles.Add(client); 
                }
                public Contact(Employees employee)
                    : this() {
                    roles.Add(employee); 
                }
            }
        public interface Role {}
        public interface Clients: Role{}
        public class BronzeClient: Clients{
            public DateTime lastClass {get; set;}
        }
        public class SilverClient : Clients {
            public DateTime lastClass {get; set;}
        }
        public class GoldClient : Clients {
            public DateTime lastClass {get; set;}
        }
        public interface Employees : Role {}
        public class Employee: Employees{
            public string EmployeeID{ get; set;}
        }
        public class SeniorManager : Employees {
            public string EmployeeID {get; set;}
        }

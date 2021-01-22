    public class Person {
        private string name;
    
        public string Name {
            get {
                return this.name;
            }
        }
    }
    
    public class Employee : Person {
        private string department;
        public string Department {
            get {
                return this.department;
            }
        }
    }

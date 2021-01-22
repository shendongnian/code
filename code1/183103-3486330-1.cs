    public class Person {
        private string name;
    
        public string Name {
            get {
                return this.name;
            }
        }
    }
    public class Department {
        private int id;
        private string name;
    
        public int ID {
            get {
                return this.id;
            }
        }
        public string Name {
            get {
                return this.name;
            }
        }
    }
    
    public class Employee : Person {
        private Department department;
        public Department Department {
            get {
                return this.department;
            }
        }
    }

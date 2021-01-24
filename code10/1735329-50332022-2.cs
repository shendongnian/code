    interface PersonSaver
    {
        void Save(Person person);
    }
    
    class PersonDao : PersonSaver {
        public void Save(Person person){
        // .. save Person to database
        }
    }
    
    class EmployeeDao : PersonSaver {
        public void Save(Person employee){
        // .. save Employee to database
        }
    }
    
    class CustomerDao : PersonSaver {
        public void Save(Person customer){
        // .. save Customer to database
        }
    }

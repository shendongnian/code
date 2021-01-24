    class Person {
        public string Name;
        public virtual PersonSaver Saver
        {
            get
            {
                return new PersonDao();
            }
        }
    }
    
    class Employee : Person {
        public int EmployeeID;
        public override PersonSaver Saver
        {
            get
            {
                return new EmployeeDao();
            }
        }
    }
    
    class Customer : Person {
        public int CustomerID;
        public override PersonSaver Saver
        {
            get
            {
                return new CustomerDao();
            }
        }
    }

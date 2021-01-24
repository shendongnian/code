    class Person 
    {
        public Person (){}
        public Person (int ID)
        {
            Id = ID;
        }
        public int Id {get; set;} 
    }
    
    class Employee: Person
       {
            private int empId;
            public Employee():base(){}
            public Employee(int emp):base(emp)
            {
                empId = emp;
            }
        }

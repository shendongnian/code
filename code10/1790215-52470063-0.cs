    class Person 
    {
        public Person (){}
        public Person (int id)
        {
            Id = id
        }
        public int Id {get;set} 
    }
    class Employee : Person
    {
        public Employee(): base(){}
        public Employee(int emp) : base(emp)
        {
            empId = Id;
        }
    }

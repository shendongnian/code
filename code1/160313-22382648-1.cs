    public class Person
    {
        private string message;
        public override string ToString()
        {
            return message;
        }
        public static Person CreateEmployee()
        {
            return new Employee();
        }
        class Employee : Person
        {
            public Employee()
            {
                this.message = "I inherit private members!";
            }
        }
    }

    public enum Sex
    {
        Male = 10,
        Female = 20
    }
    public class Employee
    {
        private Sex _sex;
        public Employee(Sex sex)
        {
           _sex = sex;
        }
    }    

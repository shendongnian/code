    internal class Employee { ... }
     
    public sealed class Program 
    {
        public static Main() 
        {
            DateTime dt = new DateTime(2016, 1, 1);
            PromoteEmployee(newYears);
        }
        public static PromoteEmployee(Object o)
        {
            Employee e = (Employee)o; //InvalidCastException, runtime error
        }
    }

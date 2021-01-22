    public abstract class Person
    {
        protected Person()
        {
        }
        protected Person( bool initialize )
        {
            if (initialize)
            {
                Initialize();
            }
        }
        // ...
    }
    public class Customer : Person
    {
        public Customer(string firstName, string lastName)
        {
           // ...
        }
    }
    public class Employee : Person
    {
        public Customer(string firstName, string lastName) : base(true)
        {
           // ...
        }
    }

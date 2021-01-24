    class Program
    {
        static void Main(string[] args)
        {
            IQuittable NewEmployee = new Employee();
    
            ((Employee)NewEmployee).FirstName = "Kitty";
            ((Employee)NewEmployee).LastName = "Katz";
    
            NewEmployee.Quit(NewEmployee);
            Console.ReadLine();
        }
    }
    
    interface IQuittable
    {
        void Quit(IQuittable Quitter);
    }
    
    public abstract class Person
    {
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    }
    
    class Employee : Person, IQuittable
    {
        public void Quit(IQuittable Quitter)
        {
            Console.WriteLine(this.FirstName + " " + this.LastName + " has quit.");
        }
    }

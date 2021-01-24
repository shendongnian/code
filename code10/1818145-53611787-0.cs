    class Program
    {
        public static void Main()
        {
            IList<Person> employees = new List<Person>(); //you need to declare this as a List/IList to get the `Add` method
            Person person = new Person();
            person.FirstName = "nuli";
            person.LastName = "swathi";
            //add this line
            employees.Add(person);
            Print.PrintFullName(employees);
            Console.ReadKey();
        }
    }

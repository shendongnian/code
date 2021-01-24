    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Employee : Person { }
    
    class Print
    {
        // The method has a parameter of the IEnumerable<Person> type.  
        public static void PrintFullName(IEnumerable<Person> persons)
        {
            foreach (Person person in persons) {
                Console.WriteLine(string.Format("Name: {0} {1}", person.FirstName, person.LastName)); // needs to format the string for it to work, hence string.format().....
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            List<Person> employees = new List<Person>(); // no need to convert it to an IEnumerable object as List already implements IEnumerable<>
            Person person = new Person();
            person.FirstName = "nuli";
            person.LastName = "swathi";
    		employees.Add(person);  // You have to populate the list first
    		Print.PrintFullName(employees);   
            Console.ReadLine();     // Changed from Console.ReadKey()
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
         class Program
        {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>(); 
            persons.Add(new Person("Jon", "Bernald", 45000.89)); 
            persons.Add(new Person("Mark", "Drake", 346.89)); 
            persons.Add(new Person("Bill", "Watts", 456.899));
            persons.SortPeople(CompareOptions.ByFirstName, SortOrder.Ascending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            persons.SortPeople(CompareOptions.ByFirstName, SortOrder.Descending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            persons.SortPeople(CompareOptions.ByLastName, SortOrder.Ascending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            persons.SortPeople(CompareOptions.ByLastName, SortOrder.Descending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            persons.SortPeople(CompareOptions.BySalary, SortOrder.Ascending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            persons.SortPeople(CompareOptions.BySalary, SortOrder.Descending);
            persons.ForEach(p => Console.WriteLine(p.ToString()));
            Console.ReadLine();
        }
    }
    public static class Extensions
    {
        public static void SortPeople(this List<Person> lst, CompareOptions opt1,SortOrder ord){
            lst.Sort((Person p1, Person p2) => 
                {
                    switch (opt1)
                    {
                        case CompareOptions.ByFirstName:
                            return ord == SortOrder.Ascending ? p1.FirstName.CompareTo(p2.FirstName) : p2.FirstName.CompareTo(p1.FirstName);
                        case CompareOptions.ByLastName:
                            return ord == SortOrder.Ascending ? p1.LastName.CompareTo(p2.LastName) : p2.LastName.CompareTo(p1.LastName);
                        case CompareOptions.BySalary:
                            return ord == SortOrder.Ascending ? p1.Salary.CompareTo(p2.Salary) : p2.Salary.CompareTo(p1.Salary);
                        default:
                            return 0;
                    }
                });
        }
    }
    
    public class Person
    {
        public double Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string first, string last, double salary)
        {
            this.Salary = salary;
            this.FirstName = first;
            this.LastName = last;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} has a salary of {2}", this.FirstName, this.LastName, this.Salary);
        }
    }
    public enum CompareOptions { ByFirstName, ByLastName, BySalary }
    public enum SortOrder { Ascending, Descending }
}

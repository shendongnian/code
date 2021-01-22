    internal class Program
    {
        private static void Main(string[] args)
        {
            IList<Person> list = new List<Person> {new Person("Bob", 40), new Person("Jill", 35)};
            IDictionary<string, Person> dictionary = list.ToDictionary(x => x.Name);
        }
    }
    public class Person
    {
        private readonly int _age;
        private readonly string _name;
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
        public int Age
        {
            get { return _age; }
        }
        public string Name
        {
            get { return _name; }
        }
    }

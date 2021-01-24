    static void Main(string[] args)
        {
            var Persons = new List<Person>();
            Persons.Add(new Person("Eric"));
            Persons[0].Childs = new List<Person>();
            Persons[0].Childs.Add(new Person("Tom"));
            Persons[0].Childs.Add(new Person("John"));
            Persons[0].Childs[0].Childs = new List<Person>();
            Persons[0].Childs[0].Childs.Add(new Person("Bill"));
            Persons.Add(new Person("John"));
            Persons = RemoveAllWithName("John", Persons);
            Persons.ForEach(x=>Print(x));
        }
        private static List<Person> RemoveAllWithName(string name, List<Person> persons)
        {
            if (persons != null && persons.Any())
            {
                persons.RemoveAll(x => x.Name == name);
            }
            if (persons != null && persons.Any())
            {
                persons.ForEach(x => RemoveAllWithName(name, x.Childs));
            }
            return persons;
        }
        private static void Print(Person person)
        {
            if (person != null)
            {
                Console.WriteLine(person.Name);
                person.Childs?.ForEach(Print);
            }
        }

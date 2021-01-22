    class Program
    {
        class NameComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, true);
            }
        }
        class Person
        {
            public Person(string id, string name)
            {
                Id = id;
                Name = name;
            }
            public string Id { get; set; }
            public string Name { get; set; }
        }
        static void Main()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("P005", "Janson"));
            persons.Add(new Person("P002", "Aravind"));
            persons.Add(new Person("P007", "Kazhal"));
            Sort(persons);
            OrderBy(persons);
            const int COUNT = 1000000;
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < COUNT; i++)
            {
                Sort(persons);
            }
            watch.Stop();
            Console.WriteLine("Sort: {0}ms", watch.ElapsedMilliseconds);
            watch = Stopwatch.StartNew();
            for (int i = 0; i < COUNT; i++)
            {
                OrderBy(persons);
            }
            watch.Stop();
            Console.WriteLine("OrderBy: {0}ms", watch.ElapsedMilliseconds);
        }
        static void Sort(List<Person> list)
        {
            list.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, true));
        }
        static void OrderBy(List<Person> list)
        {
            var result = list.OrderBy(n => n.Name, new NameComparer()).ToArray();
        }
    }

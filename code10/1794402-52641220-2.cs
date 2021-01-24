    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Age}";
        }
    }
    static void Main(string[] args) {
        personList = new List<Person>()
        {
            new Person {Name = "Jay", Age = 25},
            new Person {Name = "Hans", Age = 25},
            new Person {Name = "Fritz", Age = 25},
            new Person {Name = "Hello", Age = 26},
            new Person {Name = "World", Age = 27},
            new Person {Name = "Whatever", Age = 26},
            new Person {Name = "ASDF", Age = 24},
            new Person {Name = "Foo", Age = 25},
            new Person {Name = "Bar", Age = 22},
        };
        var ages = from p in personList
                   where p.Age > 22
                   orderby p.Age ascending
                   group p by p.Age into g
                   select (g);
        Console.WriteLine($"select(g): {ages.GetType()}");
        var ages2 = from p in personList
            where p.Age > 22
            orderby p.Age ascending
            group p by p.Age into g
            select (g.First());
        Console.WriteLine($"select(g.First()): {ages2.GetType()}");
        var ages3 = ages.First();
        Console.WriteLine($"(select(g)).First(): {ages3.GetType()}");
    }

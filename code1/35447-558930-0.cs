    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            int x = Age;  // will be 29 in this example
        }
    }
    Person person = new Person("David", 29);

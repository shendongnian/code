    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    Person person1 = new Person() { Id = 1, Name = "Person 1" };
    Person person2 = new Person() { Id = 2, Name = "Person 2" };
    Person person3 = new Person() { Id = 3, Name = "Person 3" };
    List<Person> people = new List<Person>() { person1, person2, person3 };
    //Converting to an IEnumerable
    IEnumerable<Person> IEnumerableList = people;

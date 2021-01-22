     public class Person
            {
                public int age;
                public string name;
     
                public Person(int age, string name)
                {
                    this.age = age;
                    this.name = name;
                }
            }
    List<Person> people = new List<Person>();
     
    people.Add(new Person(50, "Fred"));
    people.Add(new Person(30, "John"));
    people.Add(new Person(26, "Andrew"));
    people.Add(new Person(24, "Xavier"));
    people.Add(new Person(5, "Mark"));
    people.Add(new Person(6, "Cameron"));

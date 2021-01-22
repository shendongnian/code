    public class OverloadedClassTester
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public OverloadedClassTester (Person person)
          : this (person.Id, person.Name, person.Age) { }
        public OverloadedClassTester(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return String.Format("Id: {0}\nName: {1}\nAge: {2}\n\n", 
                Id, Name, Age);
        }
    }

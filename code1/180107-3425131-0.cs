    public class PersonCollection : List<Person>, IXmlSerializable
    {
    ...
        public void Add(string firstName, int age)
        {
            this.Add(new Person(firstName, age));
        }
    ...
    }

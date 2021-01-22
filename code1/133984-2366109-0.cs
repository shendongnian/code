    public class Person
    {
        public Person(int id)
        {
            this.Id = id;
        }
        public string Name { get;  set; }
        public int Id { get; private set; }
        public int Age { get; set; }
    }

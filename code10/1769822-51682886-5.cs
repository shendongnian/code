    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentdId { get; set; }
        public Person SubLevelPerson { get; set; }
    }
    public class TreePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Children { get; set; }
    }

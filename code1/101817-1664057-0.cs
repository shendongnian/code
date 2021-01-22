    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ICollection<Person> Relatives { get; set; }
        public Company Employer { get; set; }
    }

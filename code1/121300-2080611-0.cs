    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public void CopyTo(Person other)
        {
            other.Id = Id;
            other.Name = Name;
        }
    }

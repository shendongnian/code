    public class Person : IEquatable<Person>
    {
        public int Age { get; set; }
        public int ID { get; set; }
        
        public bool Equals(Person other)
        {
            return ID == other.ID;
        }
    }

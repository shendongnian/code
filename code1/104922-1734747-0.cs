    public class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public int ID { get; set; }
        
        public int CompareTo(Person other)
        {
            
            return Math.Sign(Age - other.Age); // -1 other greater than this
                                               // 0 if same age
                                               // 1 if this greater than other
        }
    }

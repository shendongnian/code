    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

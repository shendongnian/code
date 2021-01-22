    public struct Person
    {
        public DateTime Birthday { get; set; }
        public int Age{ get; set; }
        public String Firstname { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Age = 44, Birthday = new DateTime(1971, 5, 24), Firstname = "Emmanuel" };
            Person p2 = new Person { Age = 44, Birthday = new DateTime(1971, 5, 24), Firstname = "Emmanuel" };
            Debug.Assert(p1.Equals(p2));
            Debug.Assert(p1.GetHashCode() == p2.GetHashCode());
        }
    }

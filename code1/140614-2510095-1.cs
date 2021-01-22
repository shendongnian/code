    public class Person : ValueObject<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        protected override IEnumerable<object> Reflect()
        {
            return new object[] { Age, Name };
        }
    }

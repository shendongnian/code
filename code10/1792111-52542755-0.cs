    internal class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSimilar(TestModel other)
        {
            string myName = Name.ToLower();
            string otherName = other.Name.ToLower();
            return myName == otherName
                || myName.Contains(otherName)
                || otherName.Contains(myName);
        }
        public override string ToString()
        {
            return $"{{Id: {Id}, Name: {Name}}}";
        }
    }

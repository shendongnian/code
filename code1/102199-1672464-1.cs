    // I'll just randomly call your object Person for this example.
    class Person : IEquatable<Person> 
    {
        public string Name { get; set; }
    
        public bool Equals(Person other)
        {
            if (other == null)
                return false;
    
            return Name == other.Name;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj as Person);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    ...
    list.Distinct().ToDictionary(x => x.Name);

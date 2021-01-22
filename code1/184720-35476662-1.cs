    public class LockObject
    {
        public string Name { get; set; }
        public LockObject(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

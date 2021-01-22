    public class Class1 : IEquatable<Class1>
    {
        public Class1(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public bool Equals(Class1 other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Name, Name) && other.Id == Id;
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Id: {1}", Name, Id);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (Class1))
            {
                return false;
            }
            return Equals((Class1) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Id;
            }
        }
        public static bool operator ==(Class1 left, Class1 right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Class1 left, Class1 right)
        {
            return !Equals(left, right);
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }

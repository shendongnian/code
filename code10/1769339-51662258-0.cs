    public class Car : IEquatable<Car>
    {
        public string Description;
        public long Id;
        public bool Equals(Car other)
        {
            // Choose what you want to consider as "equal" between Car objects. 
            // For example, equality of ID means two objects are equal in this example.
            if (other == null)
                return false;
            return Id == other.Id;
        }
    }

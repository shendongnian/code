    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Person other) {
                return FirstName == other.FirstName && LastName == other.LastName;
            }
            return false;
        }
        public override int GetHashCode()
        {
            unchecked {
                return 17 * FirstName.GetHashCode() + LastName.GetHashCode();
            }
        }
    }

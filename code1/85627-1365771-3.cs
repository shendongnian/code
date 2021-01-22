    public class Author : IEquatable<Author>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Equals(Author other)
        {
            if (FirstName == other.FirstName && LastName == other.LastName)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hashFirstName = FirstName == null ? 0 : FirstName.GetHashCode();
            int hashLastName = LastName == null ? 0 : LastName.GetHashCode();
            return hashFirstName ^ hashLastName;
        }
    }

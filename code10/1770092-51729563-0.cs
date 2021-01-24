    public class GolfCourse : IEquatable<GolfCourse>
    {
        ...
        public bool Equals(GolfCourse other)
        {
            if (other == null) return false;
            return (this.Name.Equals(other.Name));
        }
    }

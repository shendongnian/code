    public class student : IComparable<student>
    {
            public int CompareTo(student other)
            {
                return name.CompareTo(other.name);
            }
      ...
    }

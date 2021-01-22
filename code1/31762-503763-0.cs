    public class Testing: IEquatable<Testing>
    {
        // getters, setters, other code
        ...
        public bool Equals(Testing other)
        {
            return other != null && other.value3 == this.value3;
        }
    }

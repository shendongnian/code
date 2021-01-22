    public class CompareObj : IEquatable<CompareObj>
    {
        public bool Equals(CompareObj other)
        {
            // example equality, customize for your object
            return (this.ExampleValue.Equals(other.ExampleValue));
        }
    }

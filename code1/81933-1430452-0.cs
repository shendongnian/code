    public class f__AnonymousType0
    {
        // Fields
        public int A { get; }
        public double B { get; }
        // Methods
        public override bool Equals(object value)
        {
            var type = value as f__AnonymousType0;
            return (((type != null)
                && EqualityComparer<int>.Default.Equals(this.A, type.A))
                && EqualityComparer<double>.Default.Equals(this.B, type.B));
        }
        public override int GetHashCode()
        {
            int num = -1134271262;
            num = (-1521134295 * num) + EqualityComparer<int>.Default.GetHashCode(this.A);
            return ((-1521134295 * num) + EqualityComparer<double>.Default.GetHashCode(this.B);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ A = ");
            builder.Append(this.A);
            builder.Append(", B = ");
            builder.Append(this.B);
            builder.Append(" }");
            return builder.ToString();
        }
    }

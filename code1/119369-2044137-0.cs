    public class Id<T>
    {
        private int RawValue
        {
            get;
            set;
        }
        public Id(int value)
        {
            this.RawValue = value;
        }
        public static explicit operator int (Id<T> id) { return id.RawValue; }
        public static implicit operator Id<T> (int value) { return new Id(value); }
    }

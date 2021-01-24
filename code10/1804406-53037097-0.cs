    public sealed class Bonus
    {
        public string ID { get; set; }
        public int Number { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Bonus other)
            {
                return ID == other.ID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID?.GetHashCode() ?? 0;
        }
    }

    public class SizeAndSpeed : IEquatable<SizeAndSpeed>
    {
        public string Size { get; set; }
        public int Speed { get; set; }
        public bool Equals(SizeAndSpeed other)
        {
            return Size == other.Size && Speed == other.Speed;
        }
    }

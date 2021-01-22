    public class ThicknessEx
    {
        public string ExtraData { get; set; }
        public Thickness Thickness { get; set; }
        public static implicit operator Thickness(ThicknessEx rhs)
        {
            return rhs.Thickness;
        }
    }

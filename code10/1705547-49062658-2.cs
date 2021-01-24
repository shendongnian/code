    public class DTO
    {
        public int Value;
        public bool CompareTo(DTO Target)
        {
            return (Target.Value == Value);
        }
        public static bool operator ==(DTO a, DTO b)
        {
            return (a.Value == b.Value);
        }
        public static bool operator !=(DTO a, DTO b)
        {
            return (a.Value != b.Value);
        }
    }

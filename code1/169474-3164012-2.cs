    public class cTag:IComparable<cTag> {
        public int id { get; set; }
        public int regnumber { get; set; }
        public string date { get; set; }
        public int CompareTo(cTag other) {
            return date.CompareTo(other.date);
        }
    }

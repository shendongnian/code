    public class TitleNumber : IComparable
    {
        private int[] Version;
        public TitleNumber(string titlenumber)
        {
            Version = titlenumber.Split('.').Select(x => int.Parse(x)).ToArray();
        }
        public int CompareTo(object obj)
        {
            if (obj is TitleNumber other)
            {
                return CompareTo(other);
            }
            else
            {
                throw new ArgumentException($"Object must be of type {nameof(TitleNumber)}");
            }
        }
        public int CompareTo(TitleNumber other)
        {
            var depth = 0;
            var depthThis = Version.Length - 1;
            var depthOther = other.Version.Length - 1;
            while (true)
            {
                if (depthThis == depth && depthOther == depth) return 0;
                if (depthOther < depth || (depthThis >= depth && Version[depth] > other.Version[depth])) return 1;
                if (depthThis < depth || Version[depth] < other.Version[depth]) return -1;
                depth++;
            }
        }
        public override bool Equals(object obj) => obj is TitleNumber other && CompareTo(other) == 0;
        public override string ToString() => string.Join(".", Version);
    }

    class Fuse : IComparable<Fuse>
    {
        public string Designator { get; set; }
        public int CompareTo(Fuse other)
        {
            if (string.IsNullOrWhiteSpace(other?.Designator)) return -1;
            if (string.IsNullOrWhiteSpace(this.Designator)) return 1;
            if (this.Designator == other.Designator) return 0;
            // get the first item in the range
            var d1Str = this.Designator.Split(new[] {',', '-'})[0];
            var d2Str = other.Designator.Split(new[] {',', '-'})[0];
            // parse to int
            var d1 = int.Parse(d1Str.Substring(1));
            var d2 = int.Parse(d2Str.Substring(1));
            return d1 > d2 ? 1 : -1;
        }
    }

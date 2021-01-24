    public class ColorNameComparer : IComparer<string>
    {
        private readonly List<string> colorOrder = new List<string>{"GY", "BL", "RD"};
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == "BK") return 1;
            if (y == "BK") return -1;
            if (colorOrder.Contains(x) && colorOrder.Contains(y))
                return colorOrder.IndexOf(x) > colorOrder.IndexOf(y) ? 1 : -1;
            if (colorOrder.Contains(x))
                return -1;
            if (colorOrder.Contains(y))
                return 1;
            return String.Compare(x, y, StringComparison.Ordinal);
        }
    }

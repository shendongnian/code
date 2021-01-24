    struct Solution
    {
        private double y;
        public static bool operator <(Solution a, Solution b)
        {
            return a.y < b.y;
        }
        public static bool operator >(Solution a, Solution b)
        {
            return a.y > b.y;
        }
    }

    public class ConfigurableFooComparer : IEqualityComparer<Foo>
    {
        private readonly bool compareBar;
        private readonly bool compareName;
        private readonly bool compareDay;
        public ConfigurableFooComparer(bool compareBar, bool compareName, bool compareDay)
        {
            this.compareBar = compareBar;
            this.compareName = compareName;
            this.compareDay = compareDay;
        }
        public bool Equals(Foo x, Foo y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (compareBar && x.Bar != y.Bar)
            {
                return false;
            }
            if (compareName && x.Name != y.Name)
            {
                return false;
            }
            if (compareDay && x.Day != y.Day)
            {
                return false;
            }
            return true;
        }
        public int GetHashCode(Foo obj)
        {
            unchecked
            {
                var hash = 0;
                if (compareBar)
                {
                    hash = hash * 17 + obj.Bar.GetHashCode();
                }
                if (compareName)
                {
                    hash = hash * 17 + (obj.Name == null ? 0 : obj.Name.GetHashCode());
                }
                if (compareDay)
                {
                    hash = hash * 17 + obj.Day.GetHashCode();
                }
                return hash;
            }
        }

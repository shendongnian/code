    public class EqualityComparer : IEqualityComparer<ScenarioResults>
    {
        public bool Equals(ScenarioResults x, ScenarioResults y)
        {
            return x.ProductSubType == y.ProductSubType && x.SubBook == y.SubBook;
        }
        public int GetHashCode(ScenarioResults obj)
        {
            return obj.ProductSubType.GetHashCode() ^ obj.SubBook.GetHashCode();
        }
    }

    public class CircuitSetComparer : IEqualityComparer<CircuitSet>
    {
    
        #region IEqualityComparer<CircuitSet> Members
    
        public bool Equals(CircuitSet x, CircuitSet y)
        {
            return x.ID == y.ID;
        }
    
        public int GetHashCode(CircuitSet obj)
        {
            return obj.ID;            
        }
    
        #endregion
    }

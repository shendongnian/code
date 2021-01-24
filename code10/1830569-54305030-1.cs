        public class ResultComparer : IEqualityComparer<Result>
        {
            public bool Equals(Result x, Result y)
            {
                // Your logic to get distinct elements
                return x.DistictFieldValue == y.DistictFieldValue;
            }
            public int GetHashCode(Result obj)
            {
                return 0; // To enforce the Equals() gets callled.
            }
        }

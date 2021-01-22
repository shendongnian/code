    public static class PortfolioState
    {
        public static PortfolioEqualityConstraint Matches(Portfolio expected)
        {
            return new PortfolioEqualityConstraint(expected);
        }
        
        public static string ToStringForTest(this Portfolio source)
        {
            return String.Format("Property1 = {0}, Property2 = {1}, Property3 = {2}.", 
                source.Property1, source.Property2, source.Property3 );
        }
    }

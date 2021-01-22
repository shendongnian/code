    public class PortfolioEqualityConstraint : Constraint
    {
        Portfolio expected;
        string expectedMessage = "";
        string actualMessage = "";
        public PortfolioEqualityConstraint(Portfolio expected)
        {
            this.expected = expected;
        }
        public override bool Matches(object actual)
        {
            if ( actual == null && expected == null ) return true;
            if ( !(actual is Portfolio) )
            { 
                expectedMessage = "<Portfolio>";
                actualMessage = "null";
                return false;
            }
            return Matches((Portfolio)actual);
        }
        private bool Matches(Portfolio actual)
        {
            if ( expected == null && actual != null )
            {
                expectedMessage = "null";
                expectedMessage = "non-null";
                return false;
            }
            if ( ReferenceEquals(expected, actual) ) return true;
            
            if ( !( expected.Property1.Equals(actual.Property1)
                     && expected.Property2.Equals(actual.Property2) 
                     && expected.Property3.Equals(actual.Property3) ) )
            {
                expectedMessage = expected.ToStringForTest();
                actualMessage = actual.ToStringForTest();
                return false;
            }
            return true;
        }
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(expectedMessage);
        }
        public override void WriteActualValueTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(actualMessage);
        }
    }

      class Outer
        {
            internal int TestVariable=0;
            internal class Inner
            {
                public Inner(int testVariable)
                {
                    InnerTestVariable = testVariable;
                }
               int InnerTestVariable; //Need to access the variabe "TestVariable" here
            }
            internal Inner CreateInner()
            {
                return new Inner(TestVariable);
            }
        }

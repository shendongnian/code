    public class SomeTests : MarshalByRefObject
    {
        [PartialTrustFact]
        public void Partial_trust_test1()
        {
            // Runs in medium trust
        }
    }
    // Or...
    [PartialTrustFixture]
    public class MoreTests : MarshalByRefObject
    {
        [Fact]
        public void Another_partial_trust_test()
        {
            // Runs in medium trust
        }
    }

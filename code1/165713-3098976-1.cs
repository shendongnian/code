    public class MyClass : IInterface
    {
        private Object Property { get; set; }
        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(Property != null);
        }
    }

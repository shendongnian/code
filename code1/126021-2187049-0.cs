    public class MyClass {
      private List<Something> nonNullList;
 
      [ContractInvariantMethod]
      void NonNullEntries() {
        Contract.Invariant(Contract.ForAll(nonNullList, el => el != null));
      }
      public void Add(Something el) {
        Contract.Requires(el != null);
      }

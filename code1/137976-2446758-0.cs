    // Interface whose implementation changes under testing
    public interface IChangesUnderTest
    {
      void DoesSomething();
    }
    // Inject this in production
    public class ProductionCode : IChangesUnderTest
    {
      void DoesSomething() { /* Does stuff */ }
    }
    // Inject this under test
    public class TestCode : IChangesUnderTest
    {
      void DoesSomething() { /* Does something else */ }
    }

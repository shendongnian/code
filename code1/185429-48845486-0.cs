    [TestClass]
    public class TransactionTest
    {
      protected EntitiesV3 context;
      protected DbContextTransaction transaction;
    
      [AssemblyInitialize]
      public static void AssemblyStart(TestContext testContext)
      {
        RetryDbConfiguration.SuspendExecutionStrategy = true;
      }
    
      [TestInitialize]
      public void TransactionTestStart()
      {
        context = new EntitiesV3();
        transaction = context.Database.BeginTransaction();
      }
    
      [TestCleanup]
      public void TransactionTestEnd()
      {
        transaction.Rollback();
        transaction.Dispose();
        context.Dispose();
      }
    
      [AssemblyCleanup]
      public static void AssemblyEnd()
      {
        RetryDbConfiguration.SuspendExecutionStrategy = false;
      }
    }

    using System.Transactions;
    using NUnit.Framework;
    namespace Crown.Util.TestUtil
    {
        [TestFixture]
        public class PersistenceTestFixture
        {
            public TransactionScope TxScope { get; private set; }
    
            [SetUp]
            public void SetUp()
            {
                TxScope = new TransactionScope();
            }
    
            [TearDown]
            public void TearDown()
            {
                if (TxScope != null)
                {
                    TxScope.Dispose();
                    TxScope = null;
                }
            }
        }
    }

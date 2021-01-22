    [TestMethod]
    [ExpectedException(typeof(ApplicationException))]
    public void TestTableInfoName()
    {
         IMapinfoWrapper mockWrapper = new MockMapinfoWrapper();
         mockWrapper.ThrowDoException(typeof(ApplicationException));
         TableInfo info = new TableInfo( mockWrapper );
         info.Do( "invalid command" );
    }

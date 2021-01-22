    private IDataReader MockIDataReader()
    {
        var moq = new Mock<IDataReader>();
        moq.SetupGet<object>( x => x["Char"] ).Returns( 'C' );
        return moq.Object;
    }
    private class TestData
    {
        public char ValidChar { get; set; }
    }
    private TestData GetTestData()
    {
        var testData = new TestData();
        using ( var reader = MockIDataReader() )
        {
           testData = new TestData
           {
               ValidChar = reader.GetChar( "Char" ).Value
           };
       }
   
       return testData;
    }

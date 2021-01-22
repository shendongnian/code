    private IDataReader MockIDataReader()
    {
        var moq = new Mock<IDataReader>();
        
        bool readToggle = true;
        
        moq.Setup(x => x.Read())
             // Returns value of local variable 'readToggle' (note that 
             // you must use lambda and not just .Returns(readToggle) 
             // because it will not be lazy initialized then)
            .Returns(() => readToggle) 
            // After 'Read()' is executed - we change 'readToggle' value 
            // so it will return false on next calls of 'Read()'
            .Callback(() => readToggle = false); 
        moq.Setup(x => x["Char"])
            .Returns('C');
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
               ValidChar = (Char)reader["Char"]
           };
       }
    
       return testData;
    }

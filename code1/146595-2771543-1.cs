    // You should pass here a list of test items, their data
    // will be returned by IDataReader
    private IDataReader MockIDataReader(List<TestData> ojectsToEmulate)
    {
        var moq = new Mock<IDataReader>();
        // This var stores current position in 'ojectsToEmulate' list
        int count = -1;
        moq.Setup(x => x.Read())
            // Return 'True' while list still has an item
            .Returns(() => count < ojectsToEmulate.Count - 1)
            // Go to next position
            .Callback(() => count++);
        moq.Setup(x => x["Char"])
            // Again, use lazy initialization via lambda expression
            .Returns(() => ojectsToEmulate[count].ValidChar);
        return moq.Object;
    }

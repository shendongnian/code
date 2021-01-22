    var resultSet = new TestData.TestDataSet();
    using (var reader = new StringReader(Resources.TestDataSetData))
    {
        resultSet.ReadXml(reader);
    }
    var testMock = new Mock<DbCommand>();
    testMock.Setup(x => x.ExecuteReader())
        .Returns(resultSet.CreateDataReader);
    testMock.Setup(x => x.ExecuteReaderAsync())
        .ReturnsAsync(resultSet.CreateDataReader);

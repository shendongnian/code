    [TestCase(typeof(CalendarGeneralCsv), typeof(CalendarGeneralCsvMap), 121)]
    public void ReadFromCsvFileWithConfigurationMapTest(Type t, Type tmap, int totalRowsExptected) {
        //Arrange
        //...
        var serviceType = csvService.GetType();
        var method = serviceType.GetMethod("ReadFileCsv");
        var genericMethod = method.MakeGenericMethod(t, tmap);
        //Act
        var records = genericMethod.Invoke(csvService, _csvToRead, ",") as IEnumerable<object>;
        //Above same as csvService.ReadFileCsv<T, Tmap>(_csvToRead, ",") as IEnumerable<object>;
        var result = new List<object>(records);
        //Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(totalRowsExptected);
    }
    

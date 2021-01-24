    public void ReadFromCsvFileWithConfigurationMapTest()
    {
        //Arrange
    
        //Act
        var records = csvService.ReadFileCsv<CalendarGeneralCsv, CalendarGeneralCsvMap>(_csvToRead, ",") as IEnumerable<object>;
    
        var result = new List<object>(records);
    
        //Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(121);
    }

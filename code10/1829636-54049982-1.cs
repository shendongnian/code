    [TestCase(typeof(CalendarGeneralCsv), typeof(CalendarGeneralCsvMap), 121)]
    public void ReadFromCsvFileWithConfigurationMapTest<T,Tmap>(int totalRowsExptected)
        where T : class
        where Tmap : class
    {
       //Arrange
        
       //Act
        var records = csvService.ReadFileCsv<T, Tmap>(_csvToRead, ",") as IEnumerable<object>;
        
         var result = new List<object>(records);
        
         //Assert
         result.Should().NotBeNullOrEmpty();
         result.Should().HaveCount(totalRowsExptected);
    }

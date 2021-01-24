    [TestCase(typeof(CalendarGeneralCsv), typeof(CalendarGeneralCsvMap), 121)]
    [TestCase(typeof(CalendarCustomCsv), typeof(CalendarCustomCsvMap), 80)]
    public void ReadFromCsvFileWithConfigurationMapTest(Type t, Type tmap, int totalRowsExpected)
    {
        GetType().GetMethod(nameof(GenericReadFromCsvFileWithConfigurationMapTest))
            .MakeGenericMethod(t, tmap)                         // <-- Type parameters go here
            .Invoke(this, new object[] { totalRowsExpected });  // <-- inputs go here
    }
    public void GenericReadFromCsvFileWithConfigurationMapTest<T, Tmap>(int totalRowsExpected)
        where T : class
        where Tmap : class
    {
        // Arrange
        // Act
        var records = csvService.ReadFileCsv<T, Tmap>(_csvToRead, ",") as IEnumerable<object>;
        // Assert
        records.Should().NotBeNull();
        var result = new List<object>(records);
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(totalRowsExptected);
    }

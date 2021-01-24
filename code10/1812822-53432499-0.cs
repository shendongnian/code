    [Test]
    public void __String_Dates_Should_Match() {
        //Arrange
        var date = "22-Nov-18 12:00:00 AM";
        var dtoObject = new[] { new DTO { Date = date } };
        var returnJson = JsonConvert.SerializeObject(dtoObject);
        //Act
        var result = JsonConvert.DeserializeObject<IEnumerable<Model>>(returnJson);
        //Assert
        result.First()
            .Should().NotBeNull()
            .And.Match<Model>(_ => _.Date == date);
    }

    [Test]
    public void YourTest()
    {
        //Arrange
        var mockRepo = new Mock<ITrackableRepository<Country>>();
        var service = new CountryService(mockRepo.Object);
        var countryArray = new Country[]{};
        //Act
        service.UpdateCountry(countryArray);
        //Assert
        mockRepo.Verify(repo => repo.Insert(It.IsAny<Country>()), Time.Once);
    }

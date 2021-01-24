    [Test]
    public void SelectedCommand_Should_Set_SelectedCar {
        // Arrange
        var expected = new Car();
        var subject = new CarViewModel();
    
        // Act
        subject.SelectedCommand.Execute(expected);
    
        // Assert    
        var actual = subject.SelectedCar;    
        Assert.AreEqual(expected, actual);
    }

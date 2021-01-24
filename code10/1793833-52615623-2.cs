    //Arrange
    var e = new Employee();
    var l = new Mock<Language>(); 
    //Act
    e.AddLanguage(l.Object);
    //Assert
    Assert.IsTrue(e.Languages.Contains(l.Object));

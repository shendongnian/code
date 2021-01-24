    //Arrange
    var e = new Employee();
    var l = new Mock<Language>(); 
    //Act
    e.AddLanguage(l);
    //Assert
    Assert.IsTrue(e.Languages.Contains(l));

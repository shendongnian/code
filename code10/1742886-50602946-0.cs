    [Test()]
    public void Parse_GivenValidDataFromXX_S_X_CSV_ShouldReturnTrue(string filename) 
    {
      // Arrange
      var parser = CreateParser(); // factory function that returns your parser
      // Act
      var result = parser.Parse("6677,6677_6677,3001,6");
      // Arrage
      Assert.IsTrue(result);
    }

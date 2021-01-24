    [Test]
    public void CheckNumberTest()
    {
    	//Arrange
       Number number = new Number();
       
       //Act
       var throws = new TestDelegate(() => number.CheckNumber(-1));
    
       //Assert.
       Assert.Throws<ArgumentOutOfRangeException>(throws);
    }

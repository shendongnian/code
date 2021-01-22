    [Test]
    public void RotateAngle_Given27Degress_Returns64Degrees()
    {
       //Arrange or Given
       var someAngleClass = new Angle();
       
       //Act or When
       var result = someAngleClass.Rotate(27);
    
       //Assert or Then
       Assert.That(result, Is.EqualTo(64));
    }

    [TestMethod]
    public void DeleteEnumeration_Should_Throw_Exception() {
        //Arrange
        var template = new TemplateDto();
        template.Template_Name = "Speed-enum.xml";
        template.Template_Type = "Enumeration";
        
        var mock = new Mock<IDBFrameworkBL>(MockBehavior.Strict);
        mock.Setup(_ => _.DeleteEnumeration(template)).Throws(new Exception());
        var controller = new DBFrameworkController(mock.Object);
        var expected = 0;
        //Act
        var actual = controller.DeleteEnumeration(template);
        //Assert
        Assert.AreEqual(expected, actual);
    }

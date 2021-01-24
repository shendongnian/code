    [TestMethod]
    public void CaseConroller_ReturnDetailData_Test() {
        //Arrange
        //mock the dependency
        var id = 100000001;
        var expected = Mock.Of<ICaseDto<object>>();
        var mockService = new Mock<ICaseProcess>();
        mockService.Setup(_ => _.GetCase(id)).Returns(expected);
        //inject it into the subject under test
        var subject = new CaseController(mockService.Object);
        
        //Act
        var actual = subject.Get(id); //exercise the test
    
        //Assert
        //assert the expected behavior
        actual.Should().BeEquivalentTo(expected);
    }

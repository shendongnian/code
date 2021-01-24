    [Fact]
    public void MyBusinessObject_ReturnsOutPutModel() {
        //Arrange
        var expected = new OutPutModel {
            // populate as needed
        }
        //mock the dependency
        var dataAccessMock = new Mock<IDataAccess>();
        //Setup the mocked dependency
        dataAccessMock
            .Setup(_ => _.SomeMethod(It.IsAny<InputModel1>(), It.IsAny<InputModel2>()))
            .Returns(expected);
        //inject the dependency into the subject under test
        var businessObject = new BusinessObject(dataAccessMock.Object);
        //needed objects for the test
        var obj1 = new InputModel1 {
            //populate as needed
        };
        var obj2 = new InputModel2 {
            //populate as needed
        };
        
        //Act
        var actual = businessObject.SomeBusinessMethod(obj1, obj2);
        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Fact]
    public void MyBusinessObject_ReturnsOutPutModel() {
        //Arrange
        var expected = new OutPutModel {
            // populate as needed
        }
        var dataAccessMock = new Mock<IDataAccess>();
        //Setup the mock
        dataAccessMock
            .Setup(_ => /*something here*/)
            .Returns(expected);
        var businessObject = new BusinessObject(dataAccessMock.Object);
        var obj1 = new InputModel1 {
            //populate as needed
        };
        var obj2 = new InputModel2 {
            //populate as needed
        };
        
        //Act
        var actual = businessObject.SomeMethod(obj1, obj2);
        //Assert
        Assert.AreEqual(expected, actual);
    }

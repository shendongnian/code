    var objMock = new Mock<Repository>();
    objMock.Setup(x=>x.Save(It.IsAny<object>)).Verifiable();
    var myclass = new MyClass{Repository = objMock.object};
    var mymessage = new Mock<Message>();
    myclass.CreateUser(mymessage.object);
    objMock.Verify(x=>x.Save(It.IsAny<object>), Times.AtLeastOnce);

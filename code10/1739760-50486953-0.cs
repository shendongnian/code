    var notificationServiceMock = new Mock<INotificationService>();
  
    notificationServiceMock.Setup(n => n.PushNotification(
                It.IsAny<long>(), 
                It.IsAny<Guid>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<DateTime>(), 
                It.IsAny<string>(), 
                It.IsAny<decimal>(), 
                It.IsAny<string>()))
            .Returns(true);
    INotificationService ntfObj = notificationServiceMock.Object;

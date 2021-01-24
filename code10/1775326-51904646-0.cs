    // Arrange the fakes
    var all = A.Fake<IScheduleHubClientContract>();
    var clients = A.Fake<IHubCallerConnectionContext<dynamic>>();
    A.CallTo(() => clients.All).Returns(all); // if All has a getter, this could be clients.All = all
    // … and arrange the system under test
    var hub = new ScheduleHub();
    hub.Clients = clients;
    // Act, by exercising the system under test
    var id = "123456789";
    hub.UpdateToCheckedIn(id);
    // Assert - verify that the expected calls were made to the Fakes
    A.CallTo(() => all.UpdateToCheckedIn(A<string>.Ignored)).MustHaveHappened();

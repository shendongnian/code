    var mock = new Mock<MyClass>() {
        CallBase = true
    };
    mock.Protected()
        .Setup<Task>("DoSomethingInternal", ItExpr.IsAny<MyContext>())
        .ThrowsAsync(new TaskCanceledException());
    var obj = mock.Object;
    await obj.DoSomething(null);

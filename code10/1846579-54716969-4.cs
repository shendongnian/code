    MyDelegate del = null;
    var mock = new Mock<MyInterface>();
    mock.SetupSet(m => m.MyDelegate = It.IsAny<MyDelegate>())
        .Callback<MyDelegate>(d => del = d);
    mock.Setup(m => m.Method(It.IsAny<int>()))
        .Callback<int>(i => del.Invoke(i));

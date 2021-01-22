    int count = 0;
    List<string> items = new List<string>();
    var mock = new Mock<IWriteFile>();
    mock.Setup(m => m.WriteData(It.IsAny<string>()))
        .Callback((string data) => { items.Add(data); count++; });

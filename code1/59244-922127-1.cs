    // Arrange
    var mo = new MyObject();
    var srcMock = new Mock<IDataReaderPlugin>();
    src.Setup(src => src.SnapshotUtc(It.IsAny<string[]>(), It.IsAny<DateTime>()))
       .Returns(new DataCollection() /* or whatever */);
    mo.SetSource(srcMock.Object);
    // ... same for m_dest
    // Act
    mo.Execute(DateTime.Now);
    // Assert
    // assert something... srcMock.Verify() or whatever

    DateTime myDate = DateTime.Now;
    
    DataCollection tags = new DataCollection();
    
    Mock<IDataReaderPlugin> dataReaderPlugin = new Mock<IDataWriterPlugin>();
    dataReaderPlugin.Setup(drp => drp.SnapshotUtc(It.IsAny<string[]>(), myDate)).Returns(tags);
    
    Mock<IDataWriterPlugin> dataWriterPlugin = new Mock<IDataWriterPlugin>();
    dataWriterPlugin.Setup(dwp => dwp.Write(tags);    
    
    MyObject mo = new MyObject();
    mo.Execute();
    
    mock.Verify(foo => foo.Write(tags));

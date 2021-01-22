    [Test]
    public void ShouldWriteToMDest()
    {
       // Arrange
       var mockDest = new Mock<IDataWriterPlugin>();
       var mockSource = new Mock<IDataReaderPlugin>();
       string[] m_dummyTags = new string[] { "tag1", "tag2", "tag3"};
    
       mockSource.Setup(source => source.SnapshotUtc(m_dummyTags, It.IsAny<DateTime>()).Returns(/*whatever you need*/);
    
       var myObj = new MyObject(mockSource.Object, mockDest.Object);
    
       // Act
       myObj.Execute(DateTime.Now);
       
    
       // Assert
       Assert.That(mockSource.Object.WhateverPropertyContainsOutput == /*Whatever you need */);
    
    }
   

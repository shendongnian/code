    var entryMock = new Mock<ICacheEntry>();
    memoryCacheMock.Setup(m => m.CreateEntry(It.IsAny<object>())
                   .Returns(entryMock.Object);
    // maybe not needed
    entryMock.Setup(e => e.SetOptions(It.IsAny<MemoryCacheEntryOptions>())
             ...

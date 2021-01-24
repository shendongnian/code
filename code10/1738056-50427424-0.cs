    var cacheRepository = new Mock<IInterface>();
    cacheRepository
        .SetupSequence(m => m.AddString(It.IsAny<string>(), It.IsAny<string>()))
        .Returns(true)
        .Returns(false);

    var moqLibraryService = new Mock<IServiceToMock>();
    moqLibraryService.Setup(ms => ms.ExecuteAsync(It.IsAny<Func<int>>()))
      .Returns( (Func<int> f) => f() );
    moqLibraryService.Setup(ms => ms.ExecuteAsync(It.IsAny<Func<string>>()))
      .Returns( (Func<string> f) => f() );

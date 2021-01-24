    //arrange
    var mockRepo = new Mock<IDocumentRepository>(MockBehavior.Strict);
    mockRepo.Setup(r => r.DeleteDocument(It.IsAny<PortalDocument>())).Throws(new Exception("test"));
    var mockLogger = new Mock<ILogger>(MockBehavior.Strict);
    mockLogger.Setup(l => l.LogCritical(It.IsAny<Exception>())).Verifiable;
    
    var controller = new DocumentController(mockRepo.Object, mockLogger.Object);
    
    //act
    var result = controller.Delete("filename", true);
    
    
    //assert
    //make sure result is a redirect result
    mockLogger.Verify();

    [Test]
    public void SavesContact()
    {
        // Arrange
        var contact = new Contact();
        var messageProcessor = new Mock<IMessageProcessor>();
        var subject = // whatever class contains the logPhoneCallDialog_SaveContact method          
        // Act
        subject.SaveContact(contact, messageProcessor.Object);
      
        // Assert
        messageProcessor.Verify(x => x.ProcessCustomerPhoneContactInfo(contact), Times.Once());
    }

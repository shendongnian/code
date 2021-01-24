    public async Task EmailService_SendingEmail_EmailSentSuccessfullyAsync() {
        //Arrange
        var test = 0;
    
        var mockEmailClient = new Mock<ISendGridClient>();
    
        mockEmailClient
            .Setup(x => x.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult((object)null)) //<-- needed to allow async flow to continue
            .Callback(() => test++);
    
        var emailSender = new EmailService(mockEmailClient.Object);
        //Act    
        await emailSender.SendAsync("mail@gmail.com", "SenderDemo", "Ilya", "EmailServiceUnitTest", "Demo", "Test",
                "<strong>Hello</strong>");
        //Assert    
        Assert.Equal(1, test);
    }

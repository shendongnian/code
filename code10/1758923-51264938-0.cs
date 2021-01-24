       public async Task EmailService_SendingEmail_EmailSentSuccessfullyAsync()
        {
            var mockEmailClient = new Mock<ISendGridClient>();
    
            mockEmailClient.Setup(x => x.SendEmailAsync(It.IsAny<YourMessageType>()));
    
            var emailSender = new EmailService(mockEmailClient.Object);
    
            await emailSender.SendAsync("mail@gmail.com", "SenderDemo", "Ilya", "EmailServiceUnitTest", "Demo", "Test",
                "<strong>Hello</strong>");
    
            mockEmailClient.Verify(x => x.SendEmailAsync(It.IsAny<YourMessageType>()), Times.Once);
        }

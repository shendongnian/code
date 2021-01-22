    var inboxMessages = this.messageRepository.GetInbox(userId1);
    Assert.That(inboxMessages.All(m => m.MessageTo == userId1);
    
    inboxMessages = this.messageRepository.GetInbox(userid2);
    Assert.That(inboxMessages.All(m => m.MessageTo = userid2);

    using (var mqFactory = appHost.TryResolve<IMessageFactory>())
    {
        var request = new ThrowVoid { Content = "Test" };
        using (var mqProducer = mqFactory.CreateMessageProducer())
        using (var mqClient = mqFactory.CreateMessageQueueClient())
        {
            mqProducer.Publish(request);
            var msg = mqClient.Get<ThrowVoid>(QueueNames<ThrowVoid>.Dlq, null);
            mqClient.Ack(msg);
            Assert.That(msg.Error.ErrorCode, Is.EqualTo("InvalidOperationException"));
        }
    }

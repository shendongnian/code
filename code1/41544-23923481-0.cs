    var types = typeof(QueueItemBase).Assembly
                .GetTypes()
                .Where(t => typeof(QueueItemBase).IsAssignableFrom(t) && t.IsAbstract == false)
                .ToArray();
    ...
    // Create and cache a message formatter instance
    _messageFormatter = new XmlMessageFormatter(types);

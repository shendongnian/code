        .Where(message => message.IsActive)
        .Select(message => new
        {
            MessageId = message.Id,
            Comment = message.Comment,
        });

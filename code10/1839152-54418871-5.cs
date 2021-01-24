    var chats = context
        .Chats
        .Where(c => c.UserChats.Any(u => u.UserId == userId1))
        .Where(c => c.UserChats.Any(u => u.UserId == userId2))
        .Select(c => new ChatDto
        {
            Id = c.Id,
            UserCount = c.UserChats.Count()
        })
        .ToList();

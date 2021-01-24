    //chats that contain user1 and user2
    var chats1 = context
        .Chats
        .Where(c => c.UserChats.Any(u => u.UserId == userId1))
        .Where(c => c.UserChats.Any(u => u.UserId == userId2))
        .ToList();
    //chats that contain user1 and user2 and they are only users in chat
    var chats2 = context
        .Chats
        .Where(c => c.UserChats.Any(u => u.UserId == userId1))
        .Where(c => c.UserChats.Any(u => u.UserId == userId2))
        .Where(c => c.UserChats.Count() == 2)
        .ToList();

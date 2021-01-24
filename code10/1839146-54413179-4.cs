     var chats = user1.UserChats.Select(uc => uc.ChatId).Distinct();
     var result1 = context.ApplicationUserChat
           .Where(a => a.UserId == user2.Id && chats.Contains(a.ChatId))
           .Select(a => a.Chat)
           .ToList();
     var result2 = results1.Except(context.ApplicationUserChat
           .Where(a => a.UserId != user2.Id 
                       && a.UserId != user2.Id 
                       && chats.Contains(a.ChatId))
           .Select(a => a.Chat)
           .Distinct())
           .ToList();

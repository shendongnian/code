       return context.Topics
       .Where(t => t.TopicID == topicId)
       .Select(t => new {
                       TopicId = t.TopicID,
                       Messages = t.Messages
                                   .Where(m => m.MessageID < messageId)
                                   .Take(2)
               }).AsNoTracking()
                 .AsEnumerable().Select(x => new Topic
                                      {
                                       TopicId = x.TopicId ,
                                       Bookings = x.Messages.ToList()
                                       }).SingleOrDefault();

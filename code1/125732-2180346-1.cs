    var result = UserRepository
          .FindAll()
          .Select(user => new
             {
                UserId    = user.UserId,
                TicketIds = TicketRepository
                               .FindAll()
                               .Where(ticket => ticket.User.UserId == user.UserId)
                               .Select(ticket => ticket.TicketId)
             });

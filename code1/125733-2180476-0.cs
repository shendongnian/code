    var users = from user in UserRepository.FindAll()
                select new UserDTO
                {
                   UserId = user.UserId,
                   Tickets = from ticket in TicketRepository.FindAll()
                             where ticket.User.UserId == user.UserId
                             select new TicketDTO
                             {
                               TicketId = ticket.TicketId
                             }
                };

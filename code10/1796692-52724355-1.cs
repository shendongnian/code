    public int SendMessage(int senderId, int receiverId, string content)
            {
                using (var dbc = new RandevouDbContext())
                { 
                    var dao = new MessagesDao(dbc);
                var usersDao = new UsersDao(dbc);
                var userService = new UserService(mapper);
                
                var sender = usersDao.Get(senderId);
                var receiver = usersDao.Get(receiverId);
                
                var entity = new Message(sender,receiver,content);
                var id = dao.Insert(entity);
                return id;
                }
            }

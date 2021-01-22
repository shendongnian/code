    class UserManagementService: IUserManagementService
    {
        public UserManagementService(IUserService userService, IUserAssociationService userAssociationService, IAssignmentService assignmentService, ILocationService locationService)
        {
            m_userService = userService;
            m_userAssociationService = userAssociationService;
            m_assignmentService = assignmentService;
            m_locationService = locationService;
        }
    
        IUserService m_userService;
        IUserAssociationService m_userAssociationService;
        IAssignmentService m_assignmentService;
        ILocationService m_locationService;
    
        User CreateUser(string name, {other user data}, assignmentID, {assignment data}, locationID, {location data})
        {
            User user = null;
            using (TransactionScope transaction = new TransactionScope())
            {
                var assignment = m_assignmentService.GetByKey(assignmentID);
                if (assignment == null)
                {
                    assignment = new Assignment { // ... };
                    assignment = m_assignmentService.Insert(assignment);
                }
    
                var location = m_locationService.GetByKey(locationID);
                if (location == null)
                {
                    location = new Location { // ... };
                    location = m_locationService.Insert(location);
                }
    
                user = new User
                {
                    Name = name,
                    // ...
                };
                user = m_userService.Insert(user);
                m_userAssociationService.AssociateWithAssignment(user, assignment);
                m_userAssociationService.AssociateWithLocation(user, location);
            }
    
            return user;
        }
    }
    
    class UserService: IUserService
    {
        public UserService(IUserDal userDal)
        {
            m_userDal = userDal;
        }
    
        IUserDal m_userDal;
        public User GetByKey(int id)
        {
            if (id < 1) throw new ArgumentException("The User ID is invalid.");
            User user = null;
            using (var reader = m_userDal.GetByID(id))
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        UserID = reader.GetInt32(reader.GerOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        // ...
                    }
                }
            }
            return user;
        }
    
        public User Insert(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            user.ID = m_userDal.AddUser(user);
            return user;
        }
    
        public User Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            m_userDal.Update(user);
            return user;
        }
        public void Delete(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            m_userDal.Delete(user);
        }
    }
    class UserDal: IUserDal
    {
        public UserDal(DbConnection connection)
        {
            m_connection = connection;
        }
        DbConnection m_connection;
        public User GetByKey(int id)
        {
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users WHERE UserID = @UserID";
                var param = command.Parameters.Add("@UserID", DbType.Int32);
                param.Value = id;
                var reader = command.ExecuteReader(CommandBehavior.SingleResult|CommandBehavior.SingleRow|CommandBehavior.CloseConnection);
                return reader;                
            }
        }
    }
    
    // Implement other CRUD services similarly

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
    
        public User Insert(User user)
        {
            user.ID = m_userDal.AddUser(user);
            return user;
        }
    
        // Implement other CRUD methods
    }
    
    // Implement other CRUD services similarly
